using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class PaymentCardDetail : BaseModel.BaseData
    {
        public int ID { get; set; }
        [MaxLength(32)]
        public string CardHolder { get; set; }
        [MaxLength(32)]
        public string CVV2 { get; set; }
        [MaxLength(32)]
        public string ExpireDate { get; set; }
        [MaxLength(32)]
        public string CardNumber { get; set; }


        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
