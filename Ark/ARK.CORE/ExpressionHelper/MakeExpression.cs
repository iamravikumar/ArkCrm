using System;
using System.Linq.Expressions;

namespace ARK.CORE.ExpressionHelper
{
    public static class CustomExpression
    {
        public static Expression<Func<T, bool>> MakeExpression<T>(object value, string propertyName)
        {
            var propertyInfoId = typeof(T).GetType().GetProperty(propertyName);
            if (propertyInfoId != null)
            {
                var memberExpression = Expression.Property(null, propertyName);
                var right = Expression.Constant(value, typeof(T));
                var predicateBody = Expression.Equal(memberExpression, right);

                Func<Expression, Expression> getParameterExpression = null;
                var parameterExpression = (ParameterExpression)getParameterExpression(predicateBody);

                return Expression.Lambda<Func<T, bool>>(predicateBody, parameterExpression);
            }
            return Expression.Lambda<Func<T, bool>>(null);
        }
    }
}
