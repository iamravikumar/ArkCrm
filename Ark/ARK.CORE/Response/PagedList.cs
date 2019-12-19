using System.Collections.Generic;
using System.Linq;
using ARK.CORE.ExpressionHelper;
using ARK.CORE.Request;

namespace ARK.CORE.Response
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        //Properties
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage
        {
            get { return (PageNumber > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageNumber + 1 < TotalPages); }
        }


        // Constructors

        public PagedList(IQueryable<T> source, FilterContainer container)
        {
            if (container == null) AddRange(source);
            else
            {

                var predicate = FilterExpressions.PreparePredicate(source, container.FilterQueries);

                var ordered = FilterOrdered.OrderedQueryable(container, source);

                if (container.FilterPage.IsPagedList)
                {
                    PageNumber = container.FilterPage.PageNumber;
                    PageSize = container.FilterPage.PageSize;

                    var total = source.Count();
                    TotalCount = total;
                    TotalPages = total / PageSize;

                    if (total % PageSize > 0)
                        TotalPages++;


                    var paged = FilterPaged.GetPagedResult(container, ordered.Where(predicate));

                    AddRange(paged);
                }
                else
                {
                    AddRange(ordered);
                }
            }
        }
    }
}
