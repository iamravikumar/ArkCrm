using ARK.CORE.Infrastructure;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain;
using ARK.MODEL.V1.Domain.Address;
using ARK.MODEL.V1.Domain.Customer;
using ARK.MODEL.V1.Enums;
using ARK.SERVICES.Service.Address;
using ARK.SERVICES.Service.CampaignService;
using ARK.SERVICES.Service.CustomerService;
using ARK.SERVICES.Service.ParameterService;
using ARK.SERVICES.Service.TaxAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerService _customerService;
        private ITaxAdministrationService _taxAdministrationService;
        private IParameterService _parameterService;
        private IAddressService _addressService;
        private ICampaignService _campaignService;

        public CustomerBusiness(
            ICustomerService customerService,
            ITaxAdministrationService taxAdministrationService,
            IParameterService parameterService,
            IAddressService addressService,
            ICampaignService campaignService
            )
        {
            _customerService = customerService;
            _taxAdministrationService = taxAdministrationService;
            _parameterService = parameterService;
            _addressService = addressService;
            _campaignService = campaignService;
        }

        public ServiceResponse<Customer> GetFilteredCustomers(FilterContainer filterContainer)
        {
            try
            {
                var asd = _customerService.GetCustomers(filterContainer);

                return new ServiceResponse<Customer>(asd, asd.PageNumber, asd.PageSize, asd.TotalCount, asd.TotalPages, asd.HasNextPage, asd.HasPreviousPage, true, 100, "Order başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ServiceResponse<CustomerModel> CreateCustomer(CustomerModel newCustomer)
        {
            try
            {
                var newCustomer2 = newCustomer.Convert<Customer>();

                var asd = _customerService.CreateCustomer(newCustomer2);

                return new ServiceResponse<CustomerModel>(newCustomer, true, 100, "Order başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ServiceResponse<CustomerModel> UpdateCustomer(CustomerModel newCustomer)
        {
            try
            {
                var newCustomer2 = newCustomer.Convert<Customer>();

                var asd = _customerService.UpdateCustomer(newCustomer2);

                return new ServiceResponse<CustomerModel>(newCustomer, true, 100, "Order başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<PreCustomerModel>> GetPreCustomer()
        {
            try
            {
                var pre = new PreCustomerModel();

                var taxCities = await _taxAdministrationService.GetTaxAdministrationCities();
                pre.TaxAdministrationCities = taxCities.Data;

                var taxDistricts = await _taxAdministrationService.GetTaxAdministrationDistricts();
                pre.TaxAdministrationDistricts = taxDistricts.Data;

                var parameters = await _parameterService.GetParameterListAsync();
                pre.MembershipTypes = parameters.Data.Where(x => x.Code == (int)ParameterListEnum.MembershipType && x.IsActive).ToList();
                pre.Genders = parameters.Data.Where(x => x.Code == (int)ParameterListEnum.Gender && x.IsActive).ToList();
                pre.IdentificationTypes = parameters.Data.Where(x => x.Code == (int)ParameterListEnum.IdentificationType && x.IsActive).ToList();
                pre.MaritalStatuses = parameters.Data.Where(x => x.Code == (int)ParameterListEnum.MaritalStatus && x.IsActive).ToList();
                pre.TTCustomerNumber = parameters.Data.FirstOrDefault(x => x.Code == (int)ParameterListEnum.TTCustomerNumber && x.IsActive);

                //var nationalities = await _addressService.GetNationalities();
                //pre.Nationalities = nationalities.Data;
                pre.Nationalities = new List<AddressNationalityModel>
                {
                    new AddressNationalityModel
                    {
                        Code = 1,
                        Name = "TÜRKİYE",
                        ID = 25
                    }
                };

                var cities = await _addressService.GetCities();
                pre.Cities = cities.Data;

                var districts = await _addressService.GetDistricts();
                pre.Districts = districts.Data;

                var townships = await _addressService.GetTownships();
                pre.Townships = townships.Data;

                var villages = await _addressService.GetVillages();
                pre.Villages = villages.Data;

                var campaignParameters = await _campaignService.GetCampaignParameterList();
                var dataa = campaignParameters.Data;
                pre.RetailerSaleChannel = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.RetailerSaleChannel) && x.IsActive).ToList();
                pre.SecureInternetProfile = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.SecureInternetProfile) && x.IsActive).ToList();
                pre.CampaignInstallmentPeriod = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.CampaignInstallmentPeriod) && x.IsActive).ToList();
                pre.BusinessType = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.BusinessType) && x.IsActive).ToList();
                pre.BusinessSubType = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.BusinessSubType) && x.IsActive).ToList();
                pre.StaticIPRequest = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.StatikIPRequest) && x.IsActive).ToList();
                pre.XdslPlacementLocation = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.XdslPlacementLocation) && x.IsActive).ToList();
                pre.Domain = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.Domain) && x.IsActive).ToList();
                pre.Jobs = dataa.Where(x => x.Code.Equals((int)CampaignParameterListEnum.Jobs) && x.IsActive).ToList();

                var campaigns = await _campaignService.GetCampaigns();
                pre.Campaigns = campaigns.Data;

                var speeds = await _campaignService.GetCampaignSpeeds();
                pre.Speeds = speeds.Data;

                return new ServiceResponse<PreCustomerModel>(pre, true, 100, "Pre Customer başarılı");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<PreCustomerModel>(ex);
            }
        }

        public async Task<ServiceResponse<List<CustomerViewModel>>> GetCustomers()
        {
            try
            {
                var asdd = await _customerService.GetCustomersAsync();
                return new ServiceResponse<List<CustomerViewModel>>(asdd.Select(ConvertExtension.Convert<CustomerViewModel>).ToList(), true, 100, "");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<ServiceResponse<List<CustomerViewModel>>> GetCustomerAccounts()
        {
            try
            {
                var asdd = await _customerService.GetCustomerAccountsAsync();
                return new ServiceResponse<List<CustomerViewModel>>(asdd.Select(ConvertExtension.Convert<CustomerViewModel>).ToList(), true, 100, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
