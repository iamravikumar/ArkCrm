using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Currency
{
    public class CurrencyModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public int? Code { get; set; }
        public bool IsActive { get; set; }
    }
}
