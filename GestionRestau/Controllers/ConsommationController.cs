using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Controllers
{
    public class Consommation : Controller
    {
        // GET: Consommation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Consommation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consommation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consommation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Consommation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consommation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Consommation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consommation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
