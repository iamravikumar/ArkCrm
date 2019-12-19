using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ARK.API.Controllers.V1
{
    public class TarifeSorgulamaController : Controller
    {
        // GET: TarifeSorgulama
        public ActionResult Index()
        {
            return View();
        }

        // GET: TarifeSorgulama/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TarifeSorgulama/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarifeSorgulama/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: TarifeSorgulama/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TarifeSorgulama/Edit/5
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

        // GET: TarifeSorgulama/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TarifeSorgulama/Delete/5
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