using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARK.WEB.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Billing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Billing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Billing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Billing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Billing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}