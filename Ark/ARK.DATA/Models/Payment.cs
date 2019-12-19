namespace ARK.DATA.Models
{
    public class Payment : BaseModel.BaseData
    {
        public int ID { get; set; }

        public int? TypeId { get; set; }
        public PaymentType Type { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }
    }
}
