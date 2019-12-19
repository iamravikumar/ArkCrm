using ARK.MODEL.V1.Domain.Account;
using ARK.MODEL.V1.Domain.Currency;
using ARK.MODEL.V1.Domain.TaxAdministration;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Retailer
{
    public class RetailerModel : BaseModel
    {
        public int ID { get; set; }
        public int? ParentRetailerID { get; set; }
        public RetailerModel ParentRetailer { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string ShortName { get; set; } //firma kısa adı
        [MaxLength(128)]
        public string TaxNumber { get; set; }
        [MaxLength(128)]
        public string MersisNumber { get; set; }
        [MaxLength(128)]
        public string SicilNo { get; set; }
        [MaxLength(128)]
        public string FaxNumber { get; set; }
        [MaxLength(128)]
        public string PhoneNumber { get; set; }
        [MaxLength(128)]
        public string PhoneNumber2 { get; set; }
        [MaxLength(256)]
        public string LogoUrl { get; set; }


        [MaxLength(128)]
        public string WebsiteName { get; set; }
        [MaxLength(128)]
        public string EmailAddress { get; set; }
        [MaxLength(128)]
        public string EmailAddress2 { get; set; }
        [MaxLength(128)]
        public string PanelUsername { get; set; }
        [MaxLength(128)]
        public string PanelPassword { get; set; }
        [MaxLength(512)]
        public string Address { get; set; }

        public int? CurrencyId { get; set; }
        public CurrencyModel Currency { get; set; }

        //Tarife Uzatma
        //Yeni Müşteri
        //Fatura Tahsil
        //Tarife Değişikliği
        //Bayi den Sms Ücreti Düşsün
        //Sms Fiyatı

        public int MaxCustomer { get; set; } //Bayinin Ekleyebileceği Müşteri Sınırı
        public bool? EnableAdminApprove { get; set; } //Bayinin Eklediği Müşteriler Admin Onayından Geçsin
        public bool? BakiyeOlustur { get; set; } //Bayiye Bakiye Oluştur
        public bool? BaskaBayiTahsilati { get; set; } //Başka Bayi Müşterilerini Tahsil Edebilsin
        public bool? HasOnlinePayment { get; set; } //Bayi Müşterileri Online Ödeme Yapsın
        public bool? BayidenKes { get; set; } //Fatura Ödeme Tutarını Bayiden Kessin
        public bool? BayiBakiyeyiKullansin { get; set; } //Bayi Bakiyeyi Kullansın
        public bool? SanalPosKullansin { get; set; } //Bayi Sanal Posu Kullansın

        //Ödeme Yöntemi Seçiniz
        //Bayi Hat/Port/İp Tanımlaması Zorunlu Olsun

        public int? CompanyTypeId { get; set; }
        public AccountCompanyTypeModel CompanyType { get; set; }
        public int? TaxAdministrationCityId { get; set; }
        public TaxAdministrationCityModel TaxAdministrationCity { get; set; }
        public int? TaxAdministrationDistrictId { get; set; }
        public TaxAdministrationDistrictModel TaxAdministrationDistrict { get; set; }

        //public int? AddressId { get; set; }
        //public AccountAddress Address { get; set; } // burası düzeltilecek
    }
}