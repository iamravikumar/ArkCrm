using ARK.MODEL.V1.Integration.TarifeSorgulama;
using System.Linq;
using System;
using System.Threading.Tasks;
using TarifeSorgulama;
using ARK.CORE.Response;

namespace ARK.SERVICES.Service.Integration
{
    public class TarifeSorgulamaService : ITarifeSorgulamaService
    {
        public async Task<ServiceResponse<TarifeSorguServisSonucModel>> TarifeSorgulamaAsync(TarifeSorgulamaRequestModel req)
        {
            try
            {
                var service = new TarifeSorgulama.TarifeSorgulamaClient();
                var response = await service.tarifeSorgulamaAsync(req.KullaniciId, req.XdslTip, req.BasvuruModeli);
                return new ServiceResponse<TarifeSorguServisSonucModel>(DTO(response.Body.tarifeSorgulamaReturn), true, 100, "asd");
                if (response.Body != null)
                {
                    return new ServiceResponse<TarifeSorguServisSonucModel>(DTO(response.Body.tarifeSorgulamaReturn), true, 100, "asd");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TarifeSorguServisSonucModel>(ex);
            }            
        }





        // DTO
        private TarifeSorguServisSonucModel DTO(TarifeSorguServisSonuc data)
        {
            if (data == null) return null;
            return new TarifeSorguServisSonucModel
            {
                Mesaj = data.mesaj,
                SonucKod = data.sonucKod,
                TarifeSorguSonuc = data.tarifeSorguSonuc.Select(DTO).ToList()
            };
        }

        private TarifeSorguSonucModel DTO(TarifeSorguSonuc data)
        {
            if (data == null) return null;
            return new TarifeSorguSonucModel
            {
                aylikSabitUcret = data.aylikSabitUcret,
                hiz = data.hiz,
                hizAciklama = data.hizAciklama,
                paketAdi = data.paketAdi,
                paketTuru = data.paketTuru,
                tarifeTuru = data.tarifeTuru
            };
        }
    }
}
