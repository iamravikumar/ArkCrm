using ARK.MODEL.V1.Domain.Payment;
using ARK.SERVICES.Service.ParameterService;
using ARK.SERVICES.Service.Payment;
using System;

namespace ARK.BUSINESS.Domain
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private IPaymentService _paymentService;
        private IParameterService _parameterService;
        public PaymentBusiness(
            IPaymentService paymentStrategy
            ,IParameterService parameterService
            )
        {
            _paymentService = paymentStrategy;
            _parameterService = parameterService;
        }
        public string Make3DPayment(Make3dPaymentRequest model)
        {
            try
            {
                var appearance = "Kuveyt";

                IPaymentFactory factory;
                switch (appearance)
                {
                    case "Kuveyt":
                        factory = new KuveytFactory();
                        break;
                    case "Iyzico":
                        factory = new IyzicoFactory();
                        break;
                    default:
                        throw new System.NotImplementedException();
                }
                _paymentService = factory.CreatePaymentInstance();

                var asd = _parameterService.GetParameter(name: "Kuveyt3DPaymentUserName");
                var model2 = new PaymentApiInfo();
                model2.ThreeDPaymentUserName = asd.Data.Value;
                model2.ThreeDPaymentPassword = asd.Data.Value;
                model2.ThreeDPaymentStoreCustomerNo = asd.Data.Value;
                model2.ThreeDPaymentStoreCode = asd.Data.Value;
                model2.ThreeDPaymentOkUrl = asd.Data.Value;
                model2.ThreeDPaymentFailUrl = asd.Data.Value;
                model2.ThreeDPaymentUrl = asd.Data.Value;

                var result = _paymentService.Make3DPayment(model);
                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public string Make3DPaymentApprove(VPosTransactionResponseContract model)
        {
            try
            {

                //return _paymentStrategy.SendApprove3DPayment(model);

                return "";
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }
    }
}
