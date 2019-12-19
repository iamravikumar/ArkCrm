using ARK.MODEL.V1.Domain.Sms;

namespace ARK.SERVICES.Service.Sms
{
    public class NidaSmsService : SmsService<NidaSmsRequest>
    {
        protected override string SendSms(NidaSmsRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}
