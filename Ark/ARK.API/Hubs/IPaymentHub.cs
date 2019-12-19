using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ARK.API.Hubs
{
    public interface IPaymentHub
    {
        Task ReceiveMessage(string user, string message);
    }
}
