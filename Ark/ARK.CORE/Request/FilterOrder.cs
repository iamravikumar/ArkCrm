namespace ARK.CORE.Request
{
    public class FilterOrder
    {
        public FilterOrder()
        {
        }

        public FilterOrder(string fieldName, OrderDirectionEnum order)
        {
            FieldName = fieldName;
            OrderDirection = order;
        }

        public string FieldName { get; set; }
        public OrderDirectionEnum OrderDirection { get; set; }
    }

    public enum OrderDirectionEnum
    {
        ASC,
        DESC
    }
}
