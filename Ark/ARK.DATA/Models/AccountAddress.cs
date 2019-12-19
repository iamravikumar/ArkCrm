using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AccountAddress : BaseModel.BaseData
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
        public AccountAddressType AddressType { get; set; }  // fatura, iletişim, kurulum adresi
        public int? NationalityId { get; set; }
        public AddressNationality Nationality { get; set; }
        public int? CityId { get; set; }
        public AddressCity City { get; set; }
        public int? DistrictId { get; set; }
        public AddressDistrict District { get; set; }
        public int? BBId { get; set; }
        public AddressBB BB { get; set; }
        public int? BuildingId { get; set; }
        public AddressBuilding Building { get; set; }
        public int? CsbmId { get; set; }
        public AddressCsbm Csbm { get; set; }
        public int? MunicipalityId { get; set; }
        public AddressMunicipality Municipality { get; set; }
        public int? QuarterId { get; set; }
        public AddressQuarter Quarter { get; set; }
        public int? TownshipId { get; set; }
        public AddressTownship Township { get; set; }
        public int? SiteId { get; set; }
        public AddressSite Site { get; set; }
        public int? VillageId { get; set; }
        public AddressVillage Village { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }
    }
}
