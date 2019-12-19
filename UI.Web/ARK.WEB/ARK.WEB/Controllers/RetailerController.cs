using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARK.WEB.Controllers
{
    public class RetailerController : Controller
    {
        // GET: Retailer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Retailer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Retailer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Retailer/Create
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

        // GET: Retailer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Retailer/Edit/5
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

        // GET: Retailer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Retailer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}