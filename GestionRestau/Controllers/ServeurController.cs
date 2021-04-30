using GestionRestau.Models;
using GestionRestau.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Controllers
{
    public class ServeurController : Controller
    {
        private readonly IServeurRepository _serveurRepository; 
        public ServeurController(IServeurRepository seveurRepository)
        {
            _serveurRepository = seveurRepository; 
        }
        
        // GET: ServeurController
        public ActionResult Index()
        {

            var serveur = _serveurRepository.GetAll(); 
            return View(serveur);
        }

        // GET: ServeurController/Details/5
        public ActionResult Details(int id)
        {
            var serveurs = _serveurRepository.GetById(id);
            return View(serveurs); 
        }

        // GET: ServeurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServeurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Serveur serveur)
        {
            
            if (!ModelState.IsValid) // par example est utliser par l'autre methode 
            {
                return View(); 
            }
            try
            {
               _serveurRepository.Insert(serveur);
               _serveurRepository.Save(); 
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServeurController/Edit/5
        public ActionResult Edit(int id)
        {


            var exist = _serveurRepository.GetById(id);
            if (exist == null) // par example est utliser par l'autre methode 
            {
                return NotFound();
            }
            var serveurs = _serveurRepository.GetById(id);
            return View(serveurs);
        }

        // POST: ServeurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Serveur serveur)
        {
           

            try
            {
                _serveurRepository.Update(serveur);
                _serveurRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServeurController/Delete/5
        public ActionResult Delete(int id)
        {
            var exist = _serveurRepository.GetById(id);
            if (exist == null) // par example est utliser par l'autre methode 
            {
                return NotFound();
            }
            var serveurs = _serveurRepository.GetById(id);
            return View(serveurs);
        }

        // POST: ServeurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Serveur serveur)
        {
            try
            {
                _serveurRepository.DelateById(id);
                _serveurRepository.Save(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
