using System.Collections.Generic;

namespace ARK.CORE.Request
{
    public class FilterContainer
    {
        public List<FilterQuery> FilterQueries { get; set; } = new List<FilterQuery>();
        public List<FilterOrder> FilterOrders { get; set; } = new List<FilterOrder>();
        public FilterPage FilterPage { get; set; } = new FilterPage();
    }
}
