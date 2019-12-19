namespace ARK.DATA.Models
{
    public class OrderProduct : BaseModel.BaseData
    {
        public int ID { get; set; }













        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
