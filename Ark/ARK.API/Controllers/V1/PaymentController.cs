using ARK.BUSINESS.Domain;
using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.Payment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ARK.API.Controllers.V1
{
    public class PaymentController : BaseController
    {
        private IPaymentBusiness _paymentBusiness;

        public PaymentController(
            IPaymentBusiness paymentBusiness
            )
        {
            _paymentBusiness = paymentBusiness;
        }

        /// <summary>
        /// asd
        /// </summary>
        /// <remarks>asd remarks</remarks>
        [HttpGet("make3DKuveytPayment", Name = "make3DKuveytPayment")]
        [ProducesResponseType(typeof(ServiceResponse<string>), 200)]
        public ServiceResponse<string> Make3DKuveytPayment(/*[FromQuery] RequestFilter requestFilter*/)
        {
            try
            {
                var req = new Make3dPaymentRequest()
                {
                    CardCVV2 = "861",
                    CardHolderName = "Halil Koca",
                    CardNumber = "4033602562020327",
                    CardExpireDateMonth = "01",
                    CardExpireDateYear = "20",
                    TotalAmount = (decimal)100
                };

                var response =_paymentBusiness.Make3DPayment(req);

                return new ServiceResponse<string>(response, true, 100, "");
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost("threeDPaymentSuccess", Name = "threeDPaymentSuccess")]
        [ProducesResponseType(typeof(ServiceResponse<string>), 200)]
        public ServiceResponse<string> ThreeDPaymentSuccess()
        {
            try
            {
                string response1 = Request.Form["AuthenticationResponse"];
                string resp = System.Web.HttpUtility.UrlDecode(response1);
                var x = new XmlSerializer(typeof(VPosTransactionResponseContract));
                var model = new VPosTransactionResponseContract();
                using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(resp)))
                {
                    var xmlreader = XmlReader.Create(ms);
                    model = x.Deserialize(xmlreader) as VPosTransactionResponseContract;
                    xmlreader.Dispose();
                }

                var response = _paymentBusiness.Make3DPaymentApprove(model);

                return new ServiceResponse<string>(response, true, 100, "");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost("threeDPaymentFail", Name = "threeDPaymentFail")]
        [ProducesResponseType(typeof(ServiceResponse<string>), 200)]
        public ServiceResponse<string> ThreeDPaymentFail()
        {
            try
            {
                string response1 = Request.Form["AuthenticationResponse"];
                string resp = System.Web.HttpUtility.UrlDecode(response1);
                var x = new XmlSerializer(typeof(VPosTransactionResponseContract));
                var model = new VPosTransactionResponseContract();
                using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(resp)))
                {
                    var xmlreader = XmlReader.Create(ms);
                    model = x.Deserialize(xmlreader) as VPosTransactionResponseContract;
                    xmlreader.Dispose();
                }

                var response = _paymentBusiness.Make3DPaymentApprove(model);

                return new ServiceResponse<string>(response, true, 100, "");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
