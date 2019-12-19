using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressCsbmModel : BaseModel
    {
        public int ID { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Name2 { get; set; }
        [MaxLength(128)]
        public string OldName { get; set; }

        public int? CsbmTypeId { get; set; }
        public AddressCsbmTypeModel CsbmType { get; set; }
        public int? QuarterCode { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarterModel Quarter { get; set; }
    }
}