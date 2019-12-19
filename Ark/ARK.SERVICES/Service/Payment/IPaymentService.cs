using ARK.MODEL.V1.Domain.Payment;

namespace ARK.SERVICES.Service.Payment
{
    public interface IPaymentService : IService
    {
        string Make3DPayment<T>(T model);
        string Make3DPaymentApprove<T>(T model);
    }
}