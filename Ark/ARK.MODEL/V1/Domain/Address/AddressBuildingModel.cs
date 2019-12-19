using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressBuildingModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }// dis kapi no
        public int? Code { get; set; }

        [MaxLength(256)]
        public string SiteName { get; set; }
        [MaxLength(256)]
        public string SiteName2 { get; set; }
        [MaxLength(256)]
        public string SiteOldName { get; set; }

        [MaxLength(256)]
        public string BlockName { get; set; }
        [MaxLength(256)]
        public string BlockName2 { get; set; }
        [MaxLength(256)]
        public string OldBlockName { get; set; }

        [MaxLength(16)]
        public string PostCode { get; set; }
        public int? OldBuildingCode { get; set; }//EsBinaKodu
        public int? CsbmCode { get; set; }
        public int? CsbmId { get; set; }
        public AddressCsbmModel Csbm { get; set; }

        public int? BuildingTypeId { get; set; }
        public AddressBuildingTypeModel BuildingType { get; set; }
    }
}