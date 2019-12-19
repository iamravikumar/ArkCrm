using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class RetailerPaymentType : BaseModel.BaseData
    {
        public int ID { get; set; }

        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }

        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}
