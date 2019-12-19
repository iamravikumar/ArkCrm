namespace ARK.MODEL.V1.Domain.Order
{
    public class OrderModel : BaseModel
    {
        public int ID { get; set; }
        public int OrderStatusId { get; set; }
        public int AcccountId { get; set; }
        public string SalesRepresentativeId { get; set; }
        public int RetailerId { get; set; }
    }
}