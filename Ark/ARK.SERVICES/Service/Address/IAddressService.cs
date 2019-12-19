using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.Address
{
    public interface IAddressService : IService
    {
        Task<ServiceResponse<List<AddressNationalityModel>>> GetNationalities();
        Task<ServiceResponse<List<AddressCityModel>>> GetCities();
        Task<ServiceResponse<List<AddressDistrictModel>>> GetDistricts();
        Task<ServiceResponse<List<AddressTownshipModel>>> GetTownships();
        Task<ServiceResponse<List<AddressVillageModel>>> GetVillages();

        Task<PagedList<AddressNationality>> GetNationalities(FilterContainer filterContainer);
        Task<PagedList<AddressCity>> GetCities(FilterContainer filterContainer);
        Task<PagedList<AddressDistrict>> GetDistricts(FilterContainer filterContainer);
        Task<PagedList<AddressMunicipality>> GetMunicipalities(FilterContainer filterContainer);        
        Task<PagedList<AddressTownship>> GetTownships(FilterContainer filterContainer);
    }
}
