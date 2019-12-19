using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressVillageModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        public int? QueueNo { get; set; } //sıra no

        public int? TownshipCode { get; set; }
        public int? TownshipId { get; set; }
        public AddressTownshipModel Township { get; set; }
    }
}
