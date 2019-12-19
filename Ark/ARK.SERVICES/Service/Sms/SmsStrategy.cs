using ARK.MODEL.V1.Domain.Sms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARK.SERVICES.Service.Sms
{
    public class SmsStrategy : ISmsStrategy
    {
        private readonly IEnumerable<ISmsService> smsServices;
        public SmsStrategy(IEnumerable<ISmsService> smsServices)
        {
            if (smsServices == null)
                throw new ArgumentNullException(nameof(smsServices));
            this.smsServices = smsServices;
        }

        public string SendSms<T>(T model) where T : ISmsModel
        {
            return GetSmsService(model).SendSms(model);
        }   

        private ISmsService GetSmsService<T>(T model) where T : ISmsModel
        {
            var result = smsServices.FirstOrDefault(p => p.AppliesTo(model.GetType()));
            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Payment service for {model.GetType().ToString()} not registered.");
            }
            return result;
        }

    }

}
