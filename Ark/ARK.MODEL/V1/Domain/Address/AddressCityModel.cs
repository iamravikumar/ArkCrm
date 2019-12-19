using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressCityModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; }

        public int? NationalityCode { get; set; }
        public int? NationalityId { get; set; }
        public AddressNationalityModel Nationality { get; set; }
    }
}
