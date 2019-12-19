using System;
using System.Threading.Tasks;
using ARK.BUSINESS.Domain;
using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.KPSPublicV1;
using ARK.MODEL.V1.Integration.KPSPublicV2;
using ARK.MODEL.V1.Integration.KPSPublicYabanciDogrula;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class KpsController : Controller
    {
        private IKpsBusiness _kpsBusiness;

        public KpsController(IKpsBusiness kpsBusiness)
        {
            _kpsBusiness = kpsBusiness;
        }

        // GET: Kps
        [HttpGet("tCKimlikNoDogrulaAsync", Name = "tCKimlikNoDogrulaAsync")]
        [ProducesResponseType(typeof(ServiceResponse<bool>), 200)]
        public async Task<ServiceResponse<bool>> TCKimlikNoDogrulaAsync([FromQuery]TCKimlikNoDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsBusiness.TCKimlikNoDogrulaAsync(request).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
                throw;
            }
        }

        [HttpGet("kisiVeCuzdanDogrulaAsync", Name = "kisiVeCuzdanDogrulaAsync")]
        [ProducesResponseType(typeof(ServiceResponse<bool>), 200)]
        public async Task<ServiceResponse<bool>> KisiVeCuzdanDogrulaAsync([FromQuery]KisiVeCuzdanDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsBusiness.KisiVeCuzdanDogrulaAsync(request).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
                throw;
            }
        }

        [HttpGet("yabanciKimlikNoDogrulaAsync", Name = "yabanciKimlikNoDogrulaAsync")]
        [ProducesResponseType(typeof(ServiceResponse<bool>), 200)]
        public async Task<ServiceResponse<bool>> YabanciKimlikNoDogrulaAsync([FromQuery]YabanciKimlikNoDogrulaRequestModel request)
        {
            try
            {
                var response = await _kpsBusiness.YabanciKimlikNoDogrulaAsync(request).ConfigureAwait(true);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
                throw;
            }
        }
    }
}