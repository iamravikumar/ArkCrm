using ARK.MODEL.V1.Domain.Payment;
using System;
using System.Linq;
using System.Reflection;

namespace ARK.SERVICES.Service.Payment
{
    //public class PaymentService : IPaymentService
    //{
    //    public string Make3DPayment<T>(T model) where T : IPaymentModel
    //    {
    //        return GetPaymentService(model).Make3DPayment(model);
    //    }

    //    public string SendApprove3DPayment<T>(T model) where T : IPaymentModel
    //    {
    //        return GetPaymentService(model).Send3DPaymentApprove(model);
    //    }

    //    private IPaymentStrategy GetPaymentService<T>(T model) where T : IPaymentModel
    //    {
    //        Type[] iLoadTypes = (from t in Assembly.Load("ARK.SERVICES").GetExportedTypes()
    //                             where !t.IsInterface && !t.IsAbstract
    //                             where typeof(IPaymentStrategy).IsAssignableFrom(t)
    //                             select t).ToArray();

    //        IPaymentStrategy[] instantiatedTypes = iLoadTypes.Select(t => (IPaymentStrategy)Activator.CreateInstance(t)).ToArray();


    //        var result = instantiatedTypes.FirstOrDefault(p => p.AppliesTo(model.GetType()));
    //        if (result == null)
    //        {
    //            throw new InvalidOperationException(
    //                $"Payment service for {model.GetType().ToString()} not registered.");
    //        }
    //        return result;
    //    }

    //}

}
