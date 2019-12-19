using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Account
{
    public class AccountStatusModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}