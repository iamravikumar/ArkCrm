using ARK.MODEL.V1.Domain.Payment;

namespace ARK.BUSINESS.Domain
{
    public interface IPaymentBusiness : IBusiness
    {
        string Make3DPayment(Make3dPaymentRequest model);
        string Make3DPaymentApprove(VPosTransactionResponseContract model);
    }
}
