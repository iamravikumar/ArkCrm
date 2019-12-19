using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.TarifeSorgulama;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public interface ITarifeSorgulamaBusiness : IBusiness
    {
        Task<ServiceResponse<TarifeSorguServisSonucModel>> TarifeSorgulamaAsync(TarifeSorgulamaRequestModel request);
    }
}
