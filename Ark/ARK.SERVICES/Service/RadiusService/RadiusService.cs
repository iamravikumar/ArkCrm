using ARK.CORE.Data;
using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.Radius;
using ARK.RADIUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.OrderService
{
    public class RadiusService : IRadiusService
    {
        private readonly IRepository<Nas> _nasRepository;

        public RadiusService(IRepository<Nas> nasRepository)
        {
            _nasRepository = nasRepository;
        }

        public async Task<ServiceResponse<Nas>> GetNasAsync()
        {
            try
            {
                var asd = await _nasRepository.TableNoTracking.FirstOrDefaultAsync();
                return new ServiceResponse<Nas>(asd, true, 100, "İşlem başarılı");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<Nas>(ex);
            }
        }

        public ServiceResponse<Nas> GetNas()
        {
            try
            {
                var asd = _nasRepository.TableNoTracking.FirstOrDefault();
                return new ServiceResponse<Nas>(asd, true, 100, "İşlem başarılı");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<Nas>(ex);
            }
        }

        public async Task<ServiceResponse<Nas>> InsertNasAsync(Nas model)
        {
            return await Task.Run(() => InsertNas(model));
        }

        public ServiceResponse<Nas> InsertNas(Nas model)
        {
            try
            {
                _nasRepository.Insert(model);

                return new ServiceResponse<Nas>(model, true, 100, "İşlem başarılı");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<Nas>(ex);
            }
        }
    }
}
