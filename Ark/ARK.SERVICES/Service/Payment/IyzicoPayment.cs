using ARK.MODEL.V1.Domain.Payment;

namespace ARK.SERVICES.Service.Payment
{
    public class IyzicoPayment : IPaymentService
    {
        public string Make3DPayment<T>(T model)
        {
            //Render a button in a Mac OS X style
            return "";
        }

        public string Make3DPaymentApprove<T>(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}
