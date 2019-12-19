using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ARK.WEB.ViewComponents
{
    public class Login : ViewComponent
    {

        public Login()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
    }
}
