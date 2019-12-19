using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public interface IEmailBusiness : IBusiness
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
