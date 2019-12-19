using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.TtAddressWebService;
using System.Threading.Tasks;
using TtAdresWebService;

namespace ARK.SERVICES.Service.Integration
{
    public interface IIntegrationTtAddressWebService : IService
    {
        Task<ServiceResponse<TTAUlkeType>> InsertNationalitiesAsync();
        Task<ServiceResponse<TTAIlType>> InsertCitiesAsync();
        Task<ServiceResponse<TTAIlceType>> InsertDistrictsAsync();
        Task<ServiceResponse<TTABelediyeTTType>> InsertMunicipalitiesAsync();
        Task<ServiceResponse<TTABucakType>> InsertTownshipAsync();
        Task<ServiceResponse<TTAKoyType>> InsertVillageAsync();
        Task<ServiceResponse<TTAMahalleType>> InsertQuarterAsync();
        Task<ServiceResponse<TTACSBMType>> InsertCsbmAsync();
        Task<ServiceResponse<TTASiteType>> InsertSitesAsync();
        //Task<ServiceResponse<TTABinaType, TTABinaModel>> InsertBuildingsAsync();
    }
}
