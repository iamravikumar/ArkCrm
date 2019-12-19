using System;
using ARK.MODEL.V1.Domain.Sms;

namespace ARK.SERVICES.Service.Sms
{
    public abstract class SmsService<TModel> : ISmsService where TModel : ISmsModel
    {
        public bool AppliesTo(Type provider)
        {
            return typeof(TModel).Equals(provider);
        }

        public string SendSms<T>(T model) where T : ISmsModel
        {
            return SendSms((TModel)(object)model);
        }

        // abstract methods
        protected abstract string SendSms(TModel model);
    }
}
