namespace ARK.CORE.Request
{
    public class FilterPage
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public bool IsPagedList { get; set; }
    }
}
