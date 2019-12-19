using ARK.MODEL.V1.Domain.Address;
using ARK.MODEL.V1.Domain.Campaign;
using ARK.MODEL.V1.Domain.Parameter;
using ARK.MODEL.V1.Domain.TaxAdministration;
using System.Collections.Generic;

namespace ARK.MODEL.V1.Domain.Customer
{
    public class PreCustomerModel
    {
        public List<TaxAdministrationCityModel> TaxAdministrationCities { get; set; }
        public List<TaxAdministrationDistrictModel> TaxAdministrationDistricts { get; set; }
        public List<ParameterListModel> MembershipTypes { get; set; }
        public List<ParameterListModel> IdentificationTypes { get; set; }
        public List<ParameterListModel> Genders { get; set; }
        public List<ParameterListModel> MaritalStatuses { get; set; }
        public List<AddressNationalityModel> Nationalities { get; set; }
        public List<AddressCityModel> Cities { get; set; }
        public List<AddressDistrictModel> Districts { get; set; }
        public List<AddressTownshipModel> Townships { get; set; }
        public List<AddressVillageModel> Villages { get; set; }
        public List<CampaignParameterListModel> RetailerSaleChannel { get; set; }
        public List<CampaignParameterListModel> SecureInternetProfile { get; set; }
        public List<CampaignParameterListModel> CampaignInstallmentPeriod { get; set; }
        public List<CampaignParameterListModel> BusinessType { get; set; }
        public List<CampaignParameterListModel> BusinessSubType { get; set; }
        public List<CampaignParameterListModel> StaticIPRequest { get; set; }
        public List<CampaignParameterListModel> XdslPlacementLocation { get; set; }
        public List<CampaignParameterListModel> Domain { get; set; }
        public List<CampaignModel> Campaigns { get; set; }
        public List<CampaignSpeedModel> Speeds { get; set; }
        public List<CampaignParameterListModel> Jobs { get; set; }
        public ParameterListModel TTCustomerNumber { get; set; }
    }
}
