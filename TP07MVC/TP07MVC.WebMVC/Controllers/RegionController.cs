using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity;
using TP07MVC.Entity.ViewModel;
using TP07MVC.Logic;

namespace TP07MVC.WebMVC.Controllers
{
    public class RegionController: Controller
    {
        private RegionLogic _logic = new RegionLogic();

        // GET: Region
        public ActionResult Index()
        {
            return View(_logic.GetAll().Select(r => new RegionViewModel(r)));
        }

        [HttpGet] // si no hay otro decorador este se toma por defecto
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegionViewModel regionModel)
        {
            try
            {
                _logic.Add(new Region(regionModel));
                return RedirectToAction("Index");
            }
            catch(IDAlreadyTakenException e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        // responds to a GET method since its called by clicking an anchor tag in Index view
        public ActionResult Delete(int id)
        {
            try
            {
                _logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch(TriedDeletingReferencedForeignKeyException ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var regionModel = new RegionViewModel(_logic.GetById(id));
                return View("Create", regionModel);
            }
            catch(IDNotFoundException ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(RegionViewModel viewModel)
        {
            try
            {
                _logic.Update(new Region(viewModel));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}