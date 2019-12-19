using Microsoft.AspNetCore.Mvc;

namespace ARK.WEB.Controllers
{
    public class MikrotikController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            return View();
        }
    }
}