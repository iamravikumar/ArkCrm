using ARK.MODEL.V1.Domain.Sms;

namespace ARK.SERVICES.Service.Sms
{
    public interface ISmsStrategy
    {
        string SendSms<T>(T model) where T : ISmsModel;
    }
}
