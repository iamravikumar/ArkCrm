using ARK.MODEL.V1.Domain.Payment;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ARK.SERVICES.Service.Payment
{
    public class KuveytPayment : IPaymentService
    {
        public string Make3DPayment<T>(T model)
        {
            try
            {
                var model2 = model as Make3dPaymentRequest;
                decimal Amount = model2.TotalAmount;//1.00TL için 100 girilmelidir.
                string CardHolderName = model2.CardHolderName;
                string CardNumber = model2.CardNumber;
                string CardExpireDateMonth = model2.CardExpireDateMonth;
                string CardExpireDateYear = model2.CardExpireDateYear;
                string CardCVV2 = model2.CardCVV2;

                string MerchantOrderId = "1"; // mağaza sipariş kodu
                string CustomerId = "400235"; //Mağaza Müsteri Numarasi
                string MerchantId = "496"; //Magaza Kodu
                string OkUrl = "https://localhost:5001/api/v1/Payment/ThreeDPaymentSuccess"; //Basarili sonuç alinirsa, yönledirelecek sayfa
                string FailUrl = "https://localhost:5001/api/v1/Payment/ThreeDPaymentFail"; //Basarisiz sonuç alinirsa, yönledirelecek sayfa
                string UserName = "apitest"; //  api rollü kullanici adı
                string Password = "api123";//  api rollü kullanici sifresi

                SHA1 sha = new SHA1CryptoServiceProvider();
                string HashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(Password)));
                string hashstr = MerchantId + MerchantOrderId + Amount.ToString() + OkUrl + FailUrl + UserName + HashedPassword;
                byte[] hashbytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(hashstr);
                byte[] inputbytes = sha.ComputeHash(hashbytes);
                string hash = Convert.ToBase64String(inputbytes);
                string HashData = hash;

                //string gServer = "https://boa.kuveytturk.com.tr/sanalposservice/Home/ThreeDModelPayGate";
                string gServer = "https://boatest.kuveytturk.com.tr/boa.virtualpos.services/Home/ThreeDModelPayGate";

                string
                postdata = "<KuveytTurkVPosMessage xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>";
                postdata += "<APIVersion>1.0.0</APIVersion>";
                postdata += "<OkUrl>" + OkUrl + "</OkUrl>";
                postdata += "<FailUrl>" + FailUrl + "</FailUrl>";
                postdata += "<HashData>" + HashData + "</HashData>";
                postdata += "<MerchantId>" + MerchantId + "</MerchantId>";
                postdata += "<CustomerId>" + CustomerId + "</CustomerId>";
                postdata += "<UserName>" + UserName + "</UserName>";
                postdata += "<CardNumber>" + CardNumber + "</CardNumber>";
                postdata += "<CardExpireDateYear>" + CardExpireDateYear + "</CardExpireDateYear>";
                postdata += "<CardExpireDateMonth>" + CardExpireDateMonth + "</CardExpireDateMonth>";
                postdata += "<CardCVV2>" + CardCVV2 + "</CardCVV2>";
                postdata += "<CardHolderName>" + CardHolderName + "</CardHolderName>";
                postdata += "<CardType>Troy</CardType>";
                postdata += "<BatchID>0</BatchID>";
                postdata += "<TransactionType>Sale</TransactionType>";
                postdata += "<InstallmentCount>0</InstallmentCount>";
                postdata += "<Amount>" + Amount + "</Amount>";
                postdata += "<DisplayAmount>" + Amount + "</DisplayAmount>";
                postdata += "<CurrencyCode>0949</CurrencyCode>";
                postdata += "<MerchantOrderId>" + MerchantOrderId + "</MerchantOrderId>";
                postdata += "<TransactionSecurity>3</TransactionSecurity>";
                postdata += "</KuveytTurkVPosMessage>";

                byte[] buffer = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(gServer);
                WebReq.Timeout = 5 * 60 * 1000;

                WebReq.Method = "POST";
                WebReq.ContentType = "application/xml";
                WebReq.ContentLength = buffer.Length;

                WebReq.CookieContainer = new CookieContainer();
                Stream ReqStream = WebReq.GetRequestStream();
                ReqStream.Write(buffer, 0, buffer.Length);

                ReqStream.Close();

                WebResponse WebRes = WebReq.GetResponse();
                Stream ResStream = WebRes.GetResponseStream();
                StreamReader ResReader = new StreamReader(ResStream);
                string responseString = ResReader.ReadToEnd();


                //string resp = UrlDecode(responseString);
                //var x = new XmlSerializer(typeof(VPosTransactionResponseContract));
                //var model = new VPosTransactionResponseContract();
                //using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(resp)))
                //{
                //    model = x.Deserialize(ms) as VPosTransactionResponseContract;
                //}

                return responseString;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string Make3DPaymentApprove<T>(T model)
        {
            try
            {
                var model2 = model as VPosTransactionResponseContract;
                string MerchantOrderId = model2.MerchantOrderId;
                string Amount = model2.VPosMessage.Amount.ToString();
                string MD = model2.MD;
                string CustomerId = "400235";// model.Vpos.VPosMessage.CustomerId; // mağaza Müsteri Numarasi
                string MerchantId = "496"; //Magaza Kodu
                string UserName = "apitest"; //  api rollü kullanici
                string Password = "api123";//  api rollü kullanici sifresi
                SHA1 sha = new SHA1CryptoServiceProvider();
                string HashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(Password)));
                string hashstr = MerchantId + MerchantOrderId + Amount.ToString() + UserName + HashedPassword;
                byte[] hashbytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(hashstr);
                byte[] inputbytes = sha.ComputeHash(hashbytes);
                string hash = Convert.ToBase64String(inputbytes);
                string HashData = hash;
                //string gServer = "https://boa.kuveytturk.com.tr/sanalposservice/Home/ThreeDModelProvisionGate";
                string gServer = "https://boatest.kuveytturk.com.tr/boa.virtualpos.services/Home/ThreeDModelProvisionGate";

                string postdata = "<KuveytTurkVPosMessage xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>";
                postdata += "<APIVersion>1.0.0</APIVersion>";
                postdata += "<HashData>" + HashData + "</HashData>";
                postdata += "<MerchantId>" + MerchantId + "</MerchantId>";
                postdata += "<CustomerId>" + CustomerId + "</CustomerId>";
                postdata += "<UserName>" + UserName + "</UserName>";
                postdata += "<CurrencyCode>0949</CurrencyCode>";
                postdata += "<TransactionType>Sale</TransactionType>";
                postdata += "<InstallmentCount>0</InstallmentCount>";
                postdata += "<Amount>" + Amount + "</Amount>";
                postdata += "<MerchantOrderId>" + MerchantOrderId + "</MerchantOrderId>";
                postdata += "<TransactionSecurity>3</TransactionSecurity>";
                postdata += "<KuveytTurkVPosAdditionalData>";
                postdata += "<AdditionalData>";
                postdata += "<Key>MD</Key>";
                postdata += "<Data>" + MD + "</Data>";
                postdata += "</AdditionalData>";
                postdata += "</KuveytTurkVPosAdditionalData>";
                postdata += "</KuveytTurkVPosMessage>";
                byte[] buffer = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(gServer);
                WebReq.Timeout = 5 * 60 * 1000;

                WebReq.Method = "POST";
                WebReq.ContentType = "application/xml";
                WebReq.ContentLength = buffer.Length;

                WebReq.CookieContainer = new CookieContainer();
                Stream ReqStream = WebReq.GetRequestStream();
                ReqStream.Write(buffer, 0, buffer.Length);

                ReqStream.Close();

                WebResponse WebRes = WebReq.GetResponse();
                Stream ResStream = WebRes.GetResponseStream();
                StreamReader ResReader = new StreamReader(ResStream);
                string responseString = ResReader.ReadToEnd();


                return responseString;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}