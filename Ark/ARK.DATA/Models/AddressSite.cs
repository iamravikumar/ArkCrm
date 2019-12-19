using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models //mahalledeki siteler
{
    public class AddressSite : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public int? QuarterCode { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarter Quarter { get; set; }
    }
}
