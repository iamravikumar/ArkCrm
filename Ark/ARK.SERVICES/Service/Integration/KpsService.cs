using ARK.CORE.Response;
using ARK.MODEL.V1.Integration.KPSPublicV1;
using ARK.MODEL.V1.Integration.KPSPublicV2;
using ARK.MODEL.V1.Integration.KPSPublicYabanciDogrula;
using KPSPublic;
using System;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.Integration
{
    public class KpsService : IKpsService
    {
        public async Task<ServiceResponse<bool>> TCKimlikNoDogrulaAsync(TCKimlikNoDogrulaRequestModel request)
        {
            try
            {
                var service = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
                var response = await service.TCKimlikNoDogrulaAsync(request.TCKimlikNo, request.Ad, request.Soyad, request.DogumYili);
                return new ServiceResponse<bool>(response.Body.TCKimlikNoDogrulaResult, true, 100, "asd");
                if (response.Body != null)
                {
                    return new ServiceResponse<bool>(response.Body.TCKimlikNoDogrulaResult, true, 100, "asd");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
            }
            
        }

        public async Task<ServiceResponse<bool>> KisiVeCuzdanDogrulaAsync(KisiVeCuzdanDogrulaRequestModel request)
        {
            try
            {
                var service = new KPSPublicV2.KPSPublicV2SoapClient(KPSPublicV2.KPSPublicV2SoapClient.EndpointConfiguration.KPSPublicV2Soap12);
                var response = await service.KisiVeCuzdanDogrulaAsync(request.TCKimlikNo, request.Ad, request.Soyad, request.SoyadYok, 
                    request.DogumGun, request.DogumGunYok, request.DogumAy, request.DogumAyYok, request.DogumYil, null, null, request.TCKKSeriNo);
                return new ServiceResponse<bool>(response.Body.KisiVeCuzdanDogrulaResult, true, 100, "asd");
                if (response.Body != null)
                {
                    return new ServiceResponse<bool>(response.Body.KisiVeCuzdanDogrulaResult, true, 100, "asd");
                }
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
                var service = new KPSPublicYabanciDogrula.KPSPublicYabanciDogrulaSoapClient(KPSPublicYabanciDogrula.KPSPublicYabanciDogrulaSoapClient.EndpointConfiguration.KPSPublicYabanciDogrulaSoap12);
                var response = await service.YabanciKimlikNoDogrulaAsync(request.KimlikNo, request.Ad, request.Soyad, request.DogumGun, request.DogumAy, request.DogumYil);
                return new ServiceResponse<bool>(response.Body.YabanciKimlikNoDogrulaResult, true, 100, "asd");
                if (response.Body != null)
                {
                    return new ServiceResponse<bool>(response.Body.YabanciKimlikNoDogrulaResult, true, 100, "asd");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(ex);
            }
        }
    }
}
