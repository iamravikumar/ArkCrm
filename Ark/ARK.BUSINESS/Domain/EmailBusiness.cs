using ARK.SERVICES.Service.Email;
using System;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public class EmailBusiness : IEmailBusiness
    {
        private IEmailService _emailService;
        public EmailBusiness(
            IEmailService emailService
            )
        {
            _emailService = emailService;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var email1 = "ihalilkoca@gmail.com";

                var subject1 = "Fullnet Deneme";

                var message1 = "Fullnet ile bağlan hayata!";

                await _emailService.SendEmailAsync(email1, subject1, message1);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
