using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class TaxAdministrationDistrict : BaseModel.BaseData
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string DistrictName { get; set; }
        public int? DistrictCode { get; set; }
        [MaxLength(128)]
        public string TaxAdministrationName { get; set; }

        public int? PlacementNo { get; set; } // sıralama no

        public int? TaxAdministrationCityId { get; set; }
        public TaxAdministrationCity TaxAdministrationCity { get; set; }
    }
}