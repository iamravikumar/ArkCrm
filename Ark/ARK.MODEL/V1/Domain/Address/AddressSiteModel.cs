using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressSiteModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public int? Code { get; set; }

        public int? QuarterCode { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarterModel Quarter { get; set; }
    }
}