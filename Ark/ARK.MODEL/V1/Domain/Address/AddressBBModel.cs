using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Address
{
    public class AddressBBModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int? Code { get; set; } //bbkcode
        public int? IndoorNo { get; set; }//IcKapiNo
        public int? BuildingNo { get; set; } //UAVT - Bina no


        public int? BBTypeId { get; set; }
        public AddressBBTypeModel BBType { get; set; }
        public int? BuildingCode { get; set; }
        public int? BuildingId { get; set; }
        public AddressBuildingModel Building { get; set; }

    }
}