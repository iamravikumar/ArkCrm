using ARK.MODEL.V1.Domain.Address;
using ARK.MODEL.V1.Domain.Retailer;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Account
{
    public class AccountAddressModel : BaseModel
    {
        public int ID { get; set; }
        public bool IsDefault { get; set; }

        public int? BuildingNo { get; set; } //UAVT - Bina no
        public int? BBCode { get; set; } //bbkcode
        public int? AddressCode { get; set; } // Adres Kodu

        [MaxLength(8)]
        public string PostCode { get; set; }
        [MaxLength(8)]
        public string FloorNo { get; set; } //kat no
        [MaxLength(8)]
        public string RoomNo { get; set; } //room no
        public int? IndoorNo { get; set; }//IcKapiNo

        public int? AddressTypeId { get; set; }
        public AccountAddressTypeModel AddressType { get; set; }  // fatura, iletişim, kurulum adresi
        public int? NationalityId { get; set; }
        public AddressNationalityModel Nationality { get; set; }
        public int? CityId { get; set; }
        public AddressCityModel City { get; set; }
        public int? DistrictId { get; set; }
        public AddressDistrictModel District { get; set; }
        public int? BBId { get; set; }
        public AddressBBModel BB { get; set; }
        public int? BuildingId { get; set; }
        public AddressBuildingModel Building { get; set; }
        public int? CsbmId { get; set; }
        public AddressCsbmModel Csbm { get; set; }
        public int? MunicipalityId { get; set; }
        public AddressMunicipalityModel Municipality { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarterModel Quarter { get; set; }
        public int? TownshipId { get; set; }
        public AddressTownshipModel Township { get; set; }
        public int? SiteId { get; set; }
        public AddressSiteModel Site { get; set; }
        public int? VillageId { get; set; }
        public AddressVillageModel Village { get; set; }

        public int? AccountId { get; set; }
        public AccountModel Account { get; set; }
        public int? RetailerId { get; set; }
        public RetailerModel Retailer { get; set; }
    }
}
