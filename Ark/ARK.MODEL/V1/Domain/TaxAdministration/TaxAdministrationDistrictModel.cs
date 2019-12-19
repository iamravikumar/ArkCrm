using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.TaxAdministration
{
    public class TaxAdministrationDistrictModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string DistrictName { get; set; }
        public int? DistrictCode { get; set; }
        [MaxLength(128)]
        public string TaxAdministrationName { get; set; }

        public int? PlacementNo { get; set; } // sıralama no

        public int? TaxAdministrationCityId { get; set; }
        public TaxAdministrationCityModel TaxAdministrationCity { get; set; }
    }
}
