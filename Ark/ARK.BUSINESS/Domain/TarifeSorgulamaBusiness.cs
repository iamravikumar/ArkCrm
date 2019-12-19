using System;
using System.Threading.Tasks;
using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.TarifeSorgulama;
using ARK.SERVICES.Service.Integration;

namespace ARK.BUSINESS.Domain
{
    public class TarifeSorgulamaBusiness : ITarifeSorgulamaBusiness
    {
        private ITarifeSorgulamaService _tarifeSorgulama;

        public TarifeSorgulamaBusiness(ITarifeSorgulamaService tarifeSorgulama)
        {
            _tarifeSorgulama = tarifeSorgulama;
        }

        public async Task<ServiceResponse<TarifeSorguServisSonucModel>> TarifeSorgulamaAsync(TarifeSorgulamaRequestModel request)
        {
            try
            {
                var response = await _tarifeSorgulama.TarifeSorgulamaAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TarifeSorguServisSonucModel>(ex);
            }
        }
    }
}
