using ARK.CORE.ApiClient;
using ARK.SHARED.ApiModels.Login;
using ARK.SHARED.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ARK.WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> LoginViaEmail(UserLoginViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                CallApi asd = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
                var asdd = await asd.AuthenticateAsync(new UserLoginModel { Username = "test", Password = "test" });

                if (true)
                {
                    HttpContext.Session.Set("", new int());
                }
                

                return Json(nameof(Index));
            }
            catch
            {
                return Json("");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RegisterNewUser(UserLoginViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                CallApi asd = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
                var asdd = await asd.AuthenticateAsync(new UserLoginModel { Username = "test", Password = "test" });

                if (true)
                {
                    HttpContext.Session.Set("", new int());
                }


                return Json(nameof(Index));
            }
            catch
            {
                return Json("");
            }
        }
    }
}