using ARK.MODEL.V1.Domain.Address;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressMunicipalityModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }

        public int? CityCode { get; set; }
        public int? CityId { get; set; }
        public AddressCityModel City { get; set; }
    }
}