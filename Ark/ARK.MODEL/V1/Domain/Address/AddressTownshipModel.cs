using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressTownshipModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }
        public int? QueueNo { get; set; } //sıra no


        public int? DistrictCode { get; set; }
        public int? DistrictId { get; set; }
        public AddressDistrictModel District { get; set; }
    }
}
