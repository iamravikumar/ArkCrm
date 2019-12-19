namespace ARK.DATA.Models
{
    public class Insurance : BaseModel.BaseData
    {
        public int ID { get; set; }
        public int? OrderId { get; set; }
        public int? InvoiceId { get; set; }
    }
}
