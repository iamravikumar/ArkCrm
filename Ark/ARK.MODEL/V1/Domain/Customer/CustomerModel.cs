using ARK.MODEL.V1.Domain.Address;

namespace ARK.MODEL.V1.Domain
{
    public class CustomerModel : BaseModel
    {
        public int ID { get; set; }
        public string CustomerNo { get; set; } //80.818.082


        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string CitizenNumber { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }

        public int BirthDate { get; set; }
        public int BirthPlaceId { get; set; }
        public AddressDistrictModel BirthPlace { get; set; }

        public string MotherMaidenName { get; set; }
        public string IdentitySerialNo { get; set; }

        public bool IsCustomer { get; set; }
        public bool IsCompetitor { get; set; }
        public bool IsPartner { get; set; }
        public bool IsChannel { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorporate { get; set; }


        // corporation
        public string TaxNumber { get; set; }
        public string MersisNumber { get; set; }
        public string CompanyName { get; set; }

        public int TaxAdministrationId { get; set; }


        public int IdentityTypeId { get; set; }
        public int JobId { get; set; }
        public int CustomerSourceId { get; set; } //
        public int CustomerTypeId { get; set; } // bireysel, kurumsal
        public int CustomerStatusId { get; set; } //
        public int NationalityId { get; set; } //uyruk

        // retailer
        public int RetailerId { get; set; }
        public string RetailerName { get; set; }
    }
}
