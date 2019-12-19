using System;
using System.Threading.Tasks;
using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.KPSPublicV1;
using ARK.MODEL.V1.Integration.KPSPublicV2;
using ARK.MODEL.V1.Integration.KPSPublicYabanciDogrula;
using ARK.SERVICES.Service.Integration;

namespace ARK.BUSINESS.Domain
{
    public class KpsBusiness : IKpsBusiness
    {
        private IKpsService _kpsService;

        public KpsBusiness(IKpsService kpsService)
        {
            _kpsService = kpsService;
        }

        public async Task<ServiceResponse<bool>> KisiVeCuzdanDogrulaAsync(KisiVeCuzdanDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsService.KisiVeCuzdanDogrulaAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
            }
        }

        public async Task<ServiceResponse<bool>> TCKimlikNoDogrulaAsync(TCKimlikNoDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsService.TCKimlikNoDogrulaAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
            }
            
        }

        public async Task<ServiceResponse<bool>> YabanciKimlikNoDogrulaAsync(YabanciKimlikNoDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsService.YabanciKimlikNoDogrulaAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
            }
        }
    }
}
