using ARK.MODEL.V1.Domain.Sms;
using System;

namespace ARK.SERVICES.Service.Sms
{
    public interface ISmsService : IService
    {
        string SendSms<T>(T model) where T : ISmsModel;
        bool AppliesTo(Type provider);
    }
}
