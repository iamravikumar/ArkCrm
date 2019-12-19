using ARK.CORE.Request;
using System.Linq;

namespace ARK.CORE.ExpressionHelper
{
    public class FilterPaged
    {
        public static IQueryable<T> GetPagedResult<T>(FilterContainer container, IQueryable<T> predicateResult)
        {
            return predicateResult
                .Skip((container.FilterPage.PageNumber - 1) * container.FilterPage.PageSize)
                .Take(container.FilterPage.PageSize);
        }
    }
    
}
