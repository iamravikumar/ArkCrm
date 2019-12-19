using ARK.MODEL.V1.Domain.Sms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace ARK.SERVICES.Service.Sms
{
    public class NetgsmSmsService : SmsService<NetgsmSmsRequest>
    {
        protected override string SendSms(NetgsmSmsRequest model)
        {
            try
            {
                model.Username = ""; // db den okunur
                model.Password = "";
                model.SourceAttr = ""; // FULLNET

                StringBuilder builder = new StringBuilder();
                builder.Append("https://api.netgsm.com.tr/sms/send/get/?");
                builder.AppendFormat("usercode={0}",model.Username);
                builder.AppendFormat("&password={0}",model.Password);
                builder.Append("&gsmno=");
                foreach (var item in model.Messages) builder.AppendFormat("{0},",item.Destination);                
                builder.Remove(builder.Length - 1, 1);
                builder.AppendFormat("&message=");
                foreach (var item in model.Messages) builder.AppendFormat("{0},", item.Message);                
                builder.Remove(builder.Length - 1, 1);
                builder.AppendFormat("&msgheader={0}",model.SourceAttr);
                builder.Append("&startdate=");
                builder.Append("&stopdate=");
                builder.Append("&dil=TR");
                string innerString = builder.ToString();

                string payload = JsonConvert.SerializeObject(innerString);

                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers["Content-Type"] = "application/json";


                //usercode	:	Sisteme giriş yaparken kullanılan kullanıcı adıdır. Bu alana abone numarası da yazılabilir (8xxxxxxxxx). 
                //İstek yapılırken gönderilmesi zorunludur.
                //password: Sisteme giriş yaparken kullanılan şifredir.
                //İstek yapılırken gönderilmesi zorunludur.
                //gsmno: Mesajın gönderileceği gsm numarasıdır. Eğer yurtdışı telefon numarasına mesaj göndermek istiyorsanız numaranın başına 00 ekleyerek gönderim işlemini yapabilirsiniz.
                //message: Mesaj metnidir. Tarifenizdeki maksimum karakterden uzun olmamalıdır.Standart maksimum karakter 917 dur.
                //msgheader   :	Sistemde tanımlı olan mesaj başlığınızdır(gönderici adınız).En az 3, en fazla 11 karakterden oluşur..Eğer mesaj başlığınızın abone numaranızın olmasını istiyorsanız, bu parametreye başında sıfır olmadan abone numaranızı yazınız.8xxxxxxxxxx
                //startdate   :	Gönderime başlayacağınız tarih. (ddMMyyyyHHmm)
                //* Boş bırakılırsa mesajınız hemen gider.
                //stopdate: İki tarih arası gönderimlerinizde bitiş tarihi.(ddMMyyyyHHmm)
                //* Boş bırakılırsa sistem başlangıç tarihine 21 saat ekleyerek otomatik gönderir.
                //dil: Türkçe karakterli mesaj gönderimlerinizde "TR" gönderilir.Eğer gönderim sağlanmazsa mesajınız türkçe karakter içermeden gönderilecektir.
                //izin: İzinli Data filtresi uygulamak istediğiniz mesaj gönderimlerinizde "1" gönderilir.Gönderilmediği taktirde filtre uygulanmadan gönderilecektir.

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
            catch (System.Exception ex)
            {

                throw;
            }

            
        }
    }
}
