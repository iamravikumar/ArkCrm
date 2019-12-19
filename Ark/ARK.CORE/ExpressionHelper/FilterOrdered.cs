using ARK.CORE.Request;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ARK.CORE.ExpressionHelper
{
    public class FilterOrdered
    {
        public static IQueryable<T> OrderedQueryable<T>(FilterContainer mapQueryFilter, IQueryable<T> predicateResult)
        {
            if (mapQueryFilter.FilterOrders.Count <= 0)
                return predicateResult;

            mapQueryFilter.FilterOrders.ForEach((order) =>
            {
                switch (order.OrderDirection)
                {
                    case OrderDirectionEnum.ASC:
                        predicateResult = OrderBy(predicateResult, "OrderBy", order.FieldName);
                        break;
                    case OrderDirectionEnum.DESC:
                        predicateResult = OrderBy(predicateResult, "OrderByDescending", order.FieldName);
                        break;
                }
            });
            return predicateResult;
        }


        public static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> query, string orderType, string memberName)
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };

            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(memberName);

            return (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    orderType,
                    new Type[] { typeof(T), pi.PropertyType },
                    query.Expression,
                    Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams))
            );
        }
    }
}
