using System.Threading.Tasks;

namespace ARK.SERVICES.Service.Email
{
    public interface IEmailService : IService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
