namespace ARK.DATA.Models
{
    public class InvoiceServiceTax
    {
        public int ID { get; set; }

        public int? InvoiceServiceId { get; set; }
        public InvoiceService InvoiceService { get; set; }

        public int? InvoiceTaxTypeId { get; set; }
        public InvoiceTaxType InvoiceTaxType { get; set; }
    }
}
