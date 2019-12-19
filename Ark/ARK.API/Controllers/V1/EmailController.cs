using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.BUSINESS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class EmailController : BaseController
    {
        private IEmailBusiness _emailBusiness;
        public EmailController(
            IEmailBusiness emailBusiness
            )
        {
            _emailBusiness = emailBusiness;
        }
        // GET: api/Email
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            
            //SshClient sshclient = new SshClient("172.0.0.1", userName, password);
            //sshclient.Connect();
            //SshCommand sc = sshclient.CreateCommand("Your Commands here");
            //sc.Execute();
            //string answer = sc.Result;

            //await _emailBusiness.SendEmailAsync("", "", "");

            return new string[] { "value1", "value2" };
        }
    }
}
