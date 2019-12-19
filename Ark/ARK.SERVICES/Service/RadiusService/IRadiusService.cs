using ARK.CORE.Response;
using ARK.RADIUS.Models;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.OrderService
{
    public interface IRadiusService : IService
    {

        Task<ServiceResponse<Nas>> GetNasAsync();
        ServiceResponse<Nas> GetNas();

        Task<ServiceResponse<Nas>> InsertNasAsync(Nas model);
        ServiceResponse<Nas> InsertNas(Nas model);

    }
}
