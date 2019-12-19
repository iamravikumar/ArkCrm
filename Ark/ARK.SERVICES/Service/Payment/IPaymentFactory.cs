namespace ARK.SERVICES.Service.Payment
{
    public interface IPaymentFactory
    {
        IPaymentService CreatePaymentInstance();
    }

    public class IyzicoFactory : IPaymentFactory
    {
        public IPaymentService CreatePaymentInstance()
        {
            return new IyzicoPayment();
        }
    }

    public class KuveytFactory : IPaymentFactory
    {
        public IPaymentService CreatePaymentInstance()
        {
            return new KuveytPayment();
        }
    }
}
