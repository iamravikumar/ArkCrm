using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class InvoiceRevision : BaseModel.BaseData
    {
        public int ID { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }





    }
}