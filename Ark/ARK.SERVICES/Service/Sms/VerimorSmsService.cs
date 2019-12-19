using ARK.MODEL.V1.Domain.Sms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace ARK.SERVICES.Service.Sms
{
    public class VerimorSmsService : SmsService<VerimorSmsRequest>
    {

        protected override string SendSms(VerimorSmsRequest model)
        {
            string payload = JsonConvert.SerializeObject(model);

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers["Content-Type"] = "application/json";

            try
            {
                string campaign_id = wc.UploadString("http://sms.verimor.com.tr/v2/send.json", payload);
                return "Mesaj gönderildi, kampanya id: " + campaign_id;
            }
            catch (WebException ex) // 400 hatalarında response body'de hatanın ne olduğunu yakalıyoruz
            {
                if (ex.Status == WebExceptionStatus.ProtocolError) // 400 hataları
                {
                    var responseBody = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    return "Mesaj gönderilemedi, dönen hata: " + responseBody;
                }
                else // diğer hatalar
                {
                    // MessageBox.Show("Mesaj gönderilemedi, dönen hata: " + ex.Status);
                    throw;
                }
            }
        }
    }
}
