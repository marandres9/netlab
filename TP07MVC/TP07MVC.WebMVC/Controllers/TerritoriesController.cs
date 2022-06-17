using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity;
using TP07MVC.Logic;

namespace TP07MVC.WebMVC.Controllers
{
    public class TerritoriesController: Controller
    {
        private readonly TerritoriesLogic _logic = new TerritoriesLogic();

        // GET: Territories
        public ActionResult Index()
        {
            return View(_logic.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Territories territory)
        {
            try
            {
                _logic.Add(territory);
                return RedirectToAction("Index");
            }
            catch(IDAlreadyTakenException ex)
            {
                return RedirectToAction("Index", "Error");

            }
            catch(EntityFailedValidationException ex)
            {
                return RedirectToAction("Index", "Error");

            }
        }

        public ActionResult Delete(string id)
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

        public ActionResult Update(string id)
        {
            try
            {
                var territory = _logic.GetById(id);
                return View("Add", territory);
            }
            catch(IDNotFoundException ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(Territories territory)
        {
            try
            {
                _logic.Update(territory);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}