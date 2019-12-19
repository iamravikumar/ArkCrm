using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Customer : BaseModel.BaseData
    {
        [Key]
        public int ID { get; set; }
        public int? CustomerId { get; set; } //80.818.082
        public long TTCustomerNo { get; set; } //tt customer no

        public bool IsActive { get; set; }

        // kimlik bilgileri

        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string MiddleName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(768)]
        public string FullName { get; set; }
        [MaxLength(32)]
        public string CitizenNumber { get; set; } // tc kimlik
        [MaxLength(256)]
        public string MotherName { get; set; }
        [MaxLength(256)]
        public string FatherName { get; set; }
        [MaxLength(256)]
        public string MotherMaidenName { get; set; }
        [MaxLength(256)]
        public string IdentitySerialNo { get; set; } // tc seri no

        

        public int? BirthDate { get; set; }
        public int? BirthPlaceId { get; set; }
        public AddressDistrict BirthPlace { get; set; }
        [MaxLength(256)]
        public string IdentityPageNo { get; set; } // sayfano
        [MaxLength(256)]
        public string IdentityVolumeNo { get; set; } //ciltno
        [MaxLength(256)]
        public string IdentityRegistryNo { get; set; } //kütük/aile sırano

        public int? NationalityId { get; set; } //uyruk
        public virtual AddressNationality Nationality { get; set; }
        public int? RegisteredCityId { get; set; }
        public AddressCity AddressCity { get; set; }
        public int? RegisteredDistrictId { get; set; }
        public AddressDistrict AddressDistrict { get; set; }
        public int? RegisteredQuarterId { get; set; }
        public AddressQuarter AddressQuarter { get; set; }
        public int? IdentityRegisteredDate { get; set; } //kimlik kayıt tarihi

        public int? JobId { get; set; }
        public virtual ParameterList Job { get; set; }
        public int? GenderId { get; set; }
        public virtual ParameterList Gender { get; set; }
        public int? IdentityTypeId { get; set; }
        public virtual ParameterList IdentityType { get; set; }
        public int? MembershipTypeId { get; set; }
        public virtual ParameterList MembershipType { get; set; }
        // kimlik bilgileri

        // corporation
        [MaxLength(64)]
        public string TaxNumber { get; set; }
        [MaxLength(64)]
        public string MersisNumber { get; set; }
        [MaxLength(512)]
        public string CompanyName { get; set; }
        public int? TaxAdministrationCityId { get; set; }
        public TaxAdministrationCity TaxAdministrationCity { get; set; }
        public int? TaxAdministrationDistrictId { get; set; }
        public TaxAdministrationDistrict TaxAdministrationDistrict { get; set; }

               
        public int? CustomerSourceId { get; set; } // müşteri referansı
        public virtual CustomerSource CustomerSource { get; set; }
        public int RetailerId { get; set; }
        public Retailer Retailer { get; set; }
    }
}

/*
 * 
 *  TC Çipli Kimlik Kartı   TC Nüfus Cüzdanı    
 TC Yabancı Kimlik Belgesi (Yabancı Misyon Kimlik Kartı, Geçici Koruma Kimlik Belgesi, İkamet İzin Belgesi, Çalışma İzni Belgesi, Vatansız Kişi Kimlik Belgesi)    
 TC Pasaportu: Yeni Tip Çipli ePasaport (Tüm Tipler)    
 TC Pasaportu: Eski Tip Lacivert (Umuma Mahsus)    
 TC Pasaportu: Eski Tip Yeşil (Hususi)    
 TC Pasaportu: Eski Tip Gri (Hizmet)    
 TC Pasaportu: Eski Tip Kırmızı (Diplomatik)    
 TC Pasaportu: Geçici Pasaport    
 Yabancı Pasaport    
 Uçuş mürettebatı belgesi    
 Gemi adamı cüzdanı    
 NATO Emri belgesi    
 Seyahat Belgesi    
 Hudut Geçiş Belgesi    
 Gemi Komutanı Onaylı Personel Listesi   TC Sürücü Belgesi   
 TC Hakim/Savcı Mesleki Kimlik Kartı   
 TC Avukatlık Belgesi   
 TC Geçici Kimlik Belgesi   
 TC Mavi Kart   
 TC Uluslararası aile cüzdanı
    */