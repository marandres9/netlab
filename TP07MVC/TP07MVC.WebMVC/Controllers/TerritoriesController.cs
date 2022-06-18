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
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SearchString = searchString;
            ViewBag.IDSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DescSortParam = (sortOrder == "description") ? "description_desc" : "description";
            var list = _logic.GetAll();

            if(!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(t => t.TerritoryDescription.Contains(searchString)).ToList();
            }

            switch(sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(t => t.TerritoryID).ToList();
                    break;
                case "description_desc":
                    list = list.OrderByDescending(t => t.TerritoryDescription).ToList();
                    break;
                case "description":
                    list = list.OrderBy(t => t.TerritoryDescription).ToList();
                    break;
                default:
                    break;
            }

            return View(list);
        }

        public ActionResult Details(string id)
        {
            try
            {
                return View(_logic.GetDetails(_logic.GetById(id)));
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
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
                return View("~/Views/Shared/Exception.cshtml", ex);

            }
            catch(EntityFailedValidationException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);

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
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                var territory = _logic.GetById(id);
                return View("Add", territory);
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpPost]
        public ActionResult Edit(Territories territory)
        {
            try
            {
                _logic.Update(territory);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

    }
}