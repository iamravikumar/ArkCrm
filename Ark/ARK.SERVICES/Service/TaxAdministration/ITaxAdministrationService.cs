using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.TaxAdministration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.TaxAdministration
{
    public interface ITaxAdministrationService : IService
    {
        Task<ServiceResponse<List<TaxAdministrationCityModel>>> GetTaxAdministrationCities();
        Task<ServiceResponse<List<TaxAdministrationDistrictModel>>> GetTaxAdministrationDistricts();
    }
}
