using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.CORE.ApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARK.WEB.Controllers
{
    
    public class CampaignController : BaseController
    {
        // GET: Campaign
        public ActionResult Index()
        {
            return View();
        }

        [Route("Index2")]
        public async Task<JsonResult> Index2()
        {
            var asd = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
            var asdd = await asd.Make3DKuveytPaymentAsync();
            return Json(asdd);
        }
      
    }
}