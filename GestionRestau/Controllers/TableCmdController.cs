using AutoMapper;
using GestionRestau.Models;
using GestionRestau.Repositories.Interfaces;
using GestionRestau.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Controllers
{
    public class TableCmdController : Controller
    {
        private readonly IServeurRepository _serveurRepository;
        private readonly ITableCmdRepository _tableCmdRepository;
        private readonly IMapper _mappper;
        public TableCmdController(ITableCmdRepository tableCmdRepository, IServeurRepository serveurRepository, IMapper mapper)
        {
            _tableCmdRepository = tableCmdRepository;
            _serveurRepository = serveurRepository;
            _mappper = mapper; 


        }

        // GET: TableCmdController
        public ActionResult Index()
        {
            var tables = _tableCmdRepository.GetAllWithServers();
           
            var tableOccupees = tables.Where(tbl => tbl.Occupation == true).Count();
            ViewData["tableOccupees"] = tableOccupees;

            var tableLibres = tables.Where(tbl => tbl.Occupation == false).Count();
            ViewData["tableLibres"] = tableLibres;

            return View(tables);
        }

        // GET: TableCmdController/Details/5
        public ActionResult Details(int id)
        {
            var details = _tableCmdRepository.GetByIdWithServeur(id);

            var mapping = _mappper.Map<DetailsTableCmdViewModel>(details);

            return View(mapping);
        }

        // GET: TableCmdController/Create
        public ActionResult Create()
        {

            TableCmdViewModel tableCmdViewModel = new TableCmdViewModel();
            tableCmdViewModel.Serveurs = _serveurRepository.GetAll()
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();

            return View(tableCmdViewModel);

        }

        // POST: TableCmdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TableCmdViewModel tableCmd)
        {
            try
            {
                //TableCmd tbl = new TableCmd();
                //tbl.Id = tableCmd.Id;
                //tbl.Numero = tableCmd.Numero;
                //tbl.NbPlace = tableCmd.NbPlace;
                //tbl.Occupation = tableCmd.Occupation;
                //tbl.Emplacement = tableCmd.Emplacement;
                //tbl.ServeurId = tableCmd.ServeurId;

                var tbl = _mappper.Map<TableCmd>(tableCmd); 
                _tableCmdRepository.Insert(tbl);
                _tableCmdRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: TableCmdController/Edit/5
        public ActionResult Edit(int id)
        {
            
       
            var tableCmd = _tableCmdRepository.GetById(id);
            var result = _mappper.Map<TableCmdViewModel>(tableCmd);


            result.Serveurs = _serveurRepository.GetAll()
               .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();

            return View(result);


            //if (tableCmd == null) // par example est utliser par l'autre methode 
            //{
            //    return NotFound();
            //}

            //ViewBag.ServeurId = _serveurRepository.GetAll()
            //    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            //return View();
        }

        // POST: TableCmdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TableCmdViewModel tableCmdViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exist = _tableCmdRepository.GetById(id);
            if (exist == null)
            {
                return NotFound();
            }

            try 
            {
                var tableCmd = _mappper.Map<TableCmd>(tableCmdViewModel);
                _tableCmdRepository.Update(tableCmd);
                _tableCmdRepository.Save();

                return RedirectToAction(nameof(Index)); 

            }
            catch 
            {
                return View();
            }

         

        }

        // GET: TableCmdController/Delete/5
        public ActionResult Delete(int id)
        {
            var exist = _tableCmdRepository.GetById(id);
            if (exist == null) // par example est utliser par l'autre methode 
            {
                return NotFound();
            }
            var tableCmd = _tableCmdRepository.GetById(id);
            return View(tableCmd);
        }

        // POST: TableCmdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _tableCmdRepository.DelateById(id);
                _tableCmdRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
