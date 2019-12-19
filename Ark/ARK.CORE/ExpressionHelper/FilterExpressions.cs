using ARK.CORE.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ARK.CORE.ExpressionHelper
{
    public class FilterExpressions
    {
        public static Expression<Func<T, bool>> PreparePredicate<T>(IQueryable<T> queryable, List<FilterQuery> filterItems)
        {
            Expression<Func<T, bool>> expression;
            var predicateBody = CreateFiltersExpressions(queryable, filterItems);

            if (predicateBody != null)
            {
                expression = MakeExpression(queryable, predicateBody);
            }
            else
            {
                expression = (x => true);
            }

            return expression;
        }

        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }

        private static Expression<Func<T, bool>> MakeExpression<T>(IQueryable<T> queryable, Expression predicateBody)
        {
            var parameterExpression = GetParameterExpression<T>(predicateBody);

            if (predicateBody is LambdaExpression)
                return (Expression<Func<T, bool>>)predicateBody;

            return Expression.Lambda<Func<T, bool>>(predicateBody, parameterExpression);
        }

        private static ParameterExpression GetParameterExpression<T>(Expression predicateBody)
        {
            Func<Expression, Expression> getParameterExpression = null;

            getParameterExpression = expression =>
            {
                if (expression is BinaryExpression)
                    return getParameterExpression(((BinaryExpression)expression).Left);

                if (expression is MemberExpression)
                    return ((MemberExpression)expression).Expression;

                if (expression is LambdaExpression)
                    return ((LambdaExpression)expression).Parameters.First();

                throw new NotImplementedException();
            };

            return (ParameterExpression)getParameterExpression(predicateBody);
        }

        public static Expression CreateFiltersExpressions<T>(IQueryable<T> query, List<FilterQuery> filterItemModels, ParameterExpression parameterExpression = null)
        {
            Expression mergedExpression = null;


            if (parameterExpression == null) parameterExpression = Expression.Parameter(query.ElementType, "x");

            for (var i = 0; i < filterItemModels.Count; i++)
            {
                var itemModel = filterItemModels[i];

                var property = query.ElementType.GetProperties().FirstOrDefault(x => x.Name == itemModel.FilterName);
                if (property == null)
                {
                    return mergedExpression;
                }

                var propertyExpression = Expression.Property(parameterExpression, itemModel.FilterName);
                Expression rightExpression = Expression.Constant(ChangeType(itemModel.FilterValue, property.PropertyType),
                    property.PropertyType);

                Expression binaryExpression;

                switch (itemModel.Condition)
                {
                    case FilterConditionEnum.Eq:
                        binaryExpression = Expression.Equal(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Neq:
                        binaryExpression = Expression.NotEqual(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Gt:
                        binaryExpression = Expression.GreaterThan(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Gteq:
                        binaryExpression = Expression.GreaterThanOrEqual(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Lt:
                        binaryExpression = Expression.LessThan(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Lteq:
                        binaryExpression = Expression.LessThanOrEqual(propertyExpression, rightExpression);
                        break;
                    case FilterConditionEnum.Con:
                        //var method = typeof(string).GetMethod("Contains", new[] { property.PropertyType });
                        //var containsMethodExpression = Expression.Call(propertyExpression, method, rightExpression);
                        //binaryExpression = Expression.Lambda<Func<T, bool>>(containsMethodExpression, parameterExpression);
                        //break;

                        binaryExpression = CreateLike<T>(property, itemModel.FilterValue);
                        break;
                    case FilterConditionEnum.Dnc:
                        var method2 = typeof(string).GetMethod("Contains", new[] { property.PropertyType });
                        var containsMethodExpression2 = Expression.Call(propertyExpression, method2, rightExpression);
                        var notContainsExpression = Expression.Not(containsMethodExpression2);
                        binaryExpression = Expression.Lambda<Func<T, bool>>(notContainsExpression, parameterExpression);
                        break;
                    case FilterConditionEnum.Reg:
                        throw new ArgumentOutOfRangeException();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                if (i > 0 && !itemModel.SubFilters.Any())
                {
                    switch (itemModel.Clause)
                    {
                        case FilterClauseEnum.And:
                            {
                                mergedExpression = Expression.And(mergedExpression, binaryExpression);
                            }
                            break;
                        case FilterClauseEnum.Or:
                            {
                                mergedExpression = Expression.Or(mergedExpression, binaryExpression);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                    mergedExpression = binaryExpression;


                if (itemModel.SubFilters.Any())
                {
                    var firstNested = itemModel.SubFilters.First();

                    switch (firstNested.Clause)
                    {
                        case FilterClauseEnum.And:
                            mergedExpression = Expression.And(mergedExpression,
                                CreateFiltersExpressions(query, itemModel.SubFilters, parameterExpression));
                            break;
                        case FilterClauseEnum.Or:
                            mergedExpression = Expression.Or(mergedExpression,
                                CreateFiltersExpressions(query, itemModel.SubFilters, parameterExpression));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                }

            }

            return mergedExpression;
        }

        private static Expression<Func<T, bool>> CreateLike<T>(PropertyInfo prop, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var parameter = Expression.Parameter(typeof(T), "f");
            var propertyAccess = Expression.MakeMemberAccess(parameter, prop);

            var indexOf = Expression.Call(propertyAccess, "IndexOf", null,
                Expression.Constant(value, typeof(string)),
                Expression.Constant(comparison));
            var like = Expression.GreaterThanOrEqual(indexOf, Expression.Constant(0));
            return Expression.Lambda<Func<T, bool>>(like, parameter);
        }
    }
}
