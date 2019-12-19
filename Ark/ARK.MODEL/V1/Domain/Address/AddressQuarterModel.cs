using ARK.MODEL.V1.Domain.Address;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressQuarterModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Name2 { get; set; }
        [MaxLength(256)]
        public string OldName { get; set; }
        [MaxLength(256)]
        public int? Code { get; set; }

        public int? MunicipalityCode { get; set; }
        public int? AuthorizedAdminCode { get; set; }
        public int QuarterTypeId { get; set; }
        public AddressQuarterTypeModel QuarterType { get; set; }
        public int? VillageCode { get; set; }
        public int? VillageId { get; set; }
        public AddressVillageModel Village { get; set; }
    }
}