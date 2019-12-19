using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ARK.WEB.Controllers
{
    public class SaleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}