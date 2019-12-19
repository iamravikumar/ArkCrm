using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.DATA.Models;
using ARK.SERVICES.Service.Integration;
using Microsoft.EntityFrameworkCore;
using ARK.CORE.Data;
using ARK.CORE.Response;
using ARK.CORE.Request;
using ARK.CORE.Infrastructure;
using ARK.MODEL.V1.Domain.Address;

namespace ARK.SERVICES.Service.Address
{
    public class AddressService : IAddressService
    {
        private IRepository<AddressNationality> _nationalityRepository;
        private IRepository<AddressCity> _cityRepository;
        private IRepository<AddressDistrict> _districtRepository;
        private IRepository<AddressMunicipality> _municipalityRepository;
        private IRepository<AddressTownship> _townshipRepository;
        private IRepository<AddressVillage> _villageRepository;
        private IRepository<AddressQuarter> _quarterRepository;
        private IRepository<AddressCsbm> _csbmRepository;
        private IRepository<AddressSite> _siteRepository;
        private readonly IRepository<AddressBuilding> _buildingRepository;
        private readonly IIntegrationTtAddressWebService _integrationTtAddressWebService;

        public AddressService(
            IIntegrationTtAddressWebService integrationTtAddressWebService,
            IRepository<AddressNationality> nationalityRepository,
            IRepository<AddressCity> cityRepository,
            IRepository<AddressDistrict> districtRepository,
            IRepository<AddressMunicipality> municipalityRepository,
            IRepository<AddressTownship> townshipRepository,
            IRepository<AddressVillage> villageRepository,
            IRepository<AddressQuarter> quarterRepository,
            IRepository<AddressCsbm> csbmRepository,
            IRepository<AddressSite> siteRepository,
            IRepository<AddressBuilding> buildingRepository
            )
        {
            _cityRepository = cityRepository;
            _nationalityRepository = nationalityRepository;
            _integrationTtAddressWebService = integrationTtAddressWebService;
            _districtRepository = districtRepository;
            _municipalityRepository = municipalityRepository;
            _townshipRepository = townshipRepository;
            _villageRepository = villageRepository;
            _quarterRepository = quarterRepository;
            _csbmRepository = csbmRepository;
            _siteRepository = siteRepository;
            _buildingRepository = buildingRepository;
        }

        public async Task<ServiceResponse<List<AddressNationalityModel>>> GetNationalities()
        {
            var nationalities = await _nationalityRepository.TableNoTracking.ToListAsync();
            return new ServiceResponse<List<AddressNationalityModel>>(nationalities.Select(ConvertExtension.Convert<AddressNationalityModel>).ToList(), true, 100, "");
        }

        public async Task<ServiceResponse<List<AddressCityModel>>> GetCities()
        {
            var cities = await _cityRepository.TableNoTracking.ToListAsync();
            return new ServiceResponse<List<AddressCityModel>>(cities.Select(ConvertExtension.Convert<AddressCityModel>).ToList(), true, 100, "");
        }

        public async Task<ServiceResponse<List<AddressDistrictModel>>> GetDistricts()
        {
            var districts = await _districtRepository.TableNoTracking.ToListAsync();
            return new ServiceResponse<List<AddressDistrictModel>>(districts.Select(ConvertExtension.Convert<AddressDistrictModel>).ToList(), true, 100, "");
        }

        public async Task<ServiceResponse<List<AddressTownshipModel>>> GetTownships()
        {
            var cities = await _townshipRepository.TableNoTracking.ToListAsync();
            return new ServiceResponse<List<AddressTownshipModel>>(cities.Select(ConvertExtension.Convert<AddressTownshipModel>).ToList(), true, 100, "");
        }

        public async Task<ServiceResponse<List<AddressVillageModel>>> GetVillages()
        {
            var cities = await _villageRepository.TableNoTracking.ToListAsync();
            return new ServiceResponse<List<AddressVillageModel>>(cities.Select(ConvertExtension.Convert<AddressVillageModel>).ToList(), true, 100, "");
        }


        //***********************************//


        public async Task<PagedList<AddressNationality>> GetNationalities(FilterContainer filterContainer)
        {
            var nationalities = _nationalityRepository.TableNoTracking;
            return new PagedList<AddressNationality>(nationalities, filterContainer);
        }

        public async Task<PagedList<AddressCity>> GetCities(FilterContainer filterContainer)
        {
            var cities = _cityRepository.TableNoTracking;

            return new PagedList<AddressCity>(cities, filterContainer);
        }

        public async Task<PagedList<AddressDistrict>> GetDistricts(FilterContainer filterContainer)
        {
            var districts = _districtRepository.TableNoTracking;

            return new PagedList<AddressDistrict>(districts, filterContainer);
        }

        public async Task<PagedList<AddressMunicipality>> GetMunicipalities(FilterContainer filterContainer)
        {
            var municipalities = _municipalityRepository.TableNoTracking;

            return new PagedList<AddressMunicipality>(municipalities, filterContainer);
        }

        public async Task<PagedList<AddressTownship>> GetTownships(FilterContainer filterContainer)
        {
            var townships = _townshipRepository.TableNoTracking;

            return new PagedList<AddressTownship>(townships, filterContainer);
        }
    }
}
