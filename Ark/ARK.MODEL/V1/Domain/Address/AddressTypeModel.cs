using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressTypeModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}