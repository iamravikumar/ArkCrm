using ARK.CORE.Response;
using ARK.RADIUS.Models;
using ARK.SERVICES.Service.OrderService;
using System;

namespace ARK.BUSINESS.Domain
{
    public class RadiusBusiness : IRadiusBusiness
    {
        private readonly IRadiusService _radiusService;

        public RadiusBusiness(IRadiusService radiusService)
        {
            _radiusService = radiusService;
        }
        public ServiceResponse<Nas> GetNas()
        {
            try
            {
                var asd = _radiusService.GetNas();

                return new ServiceResponse<Nas>(asd.Data, true, 100, "Order başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
