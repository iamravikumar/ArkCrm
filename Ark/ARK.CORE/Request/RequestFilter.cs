namespace ARK.CORE.Request
{
    public class RequestFilter
    {
        public RequestFilter()
        {
            Filtering = new FilterQuery[] { };
            Ordering = new FilterOrder[] { };
            Paging = new FilterPage();
        }
        public RequestFilter(string fieldName, string value)
        {
            Filtering = new FilterQuery[]
            {
                new FilterQuery(fieldName, FilterClauseEnum.And, FilterConditionEnum.Eq, value)
            };
        }

        public FilterQuery[] Filtering { get; set; } = new FilterQuery[] { };
        public FilterOrder[] Ordering { get; set; } = new FilterOrder[] { };
        public FilterPage Paging { get; set; } = new FilterPage();
    }
}
