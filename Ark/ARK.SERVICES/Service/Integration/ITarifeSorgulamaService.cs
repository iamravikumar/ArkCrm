using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.TarifeSorgulama;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.Integration
{
    public interface ITarifeSorgulamaService : IService
    {
        Task<ServiceResponse<TarifeSorguServisSonucModel>> TarifeSorgulamaAsync(TarifeSorgulamaRequestModel req);
    }
}
