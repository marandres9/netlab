using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;
using TP07MVC.Logic;
using TP07MVC.WebMVC.Models;

namespace TP07MVC.WebMVC.Controllers
{
    public class RegionController: Controller
    {
        private readonly RegionLogic _logic = new RegionLogic();

        // GET: Region
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SearchString = searchString;
            ViewBag.IDSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DescSortParam = (sortOrder == "description") ? "description_desc" : "description";
            var list = _logic.GetAll().Select(r => new RegionModel(r));

            if(!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(r => r.RegionDescription.Contains(searchString)).ToList();
            }
            switch(sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(r => r.RegionID).ToList();
                    break;
                case "description_desc":
                    list = list.OrderByDescending(r => r.RegionDescription).ToList();
                    break;
                case "description":
                    list = list.OrderBy(r => r.RegionDescription).ToList();
                    break;
                default:
                    break;
            }

            return View(list);
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(_logic.GetDetails(id));
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpGet] // si no hay otro decorador este se toma por defecto
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RegionModel regionModel)
        {
            // Validate object and check if ID already exists
            // (only for entities without auto-incrementing PK's)
            if(!ModelState.IsValid)
            {
                return View(regionModel);
            }
            else if(_logic.Exists(regionModel.RegionID))
            {
                ModelState.AddModelError("id-taken", "Region ID already exists");
                return View(regionModel);
            }
            // add and save object
            try
            {
                _logic.Add(new RegionDto { RegionID = regionModel.RegionID, RegionDescription = regionModel.RegionDescription });
                return RedirectToAction("Index");
            }
            catch(IDAlreadyTakenException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var regionModel = new RegionModel(_logic.Get(id));
                ViewBag.Editing = true;
                // uses Add view for editing, the displayed content depends on the ViewBag.Editing property
                return View("Add", regionModel);
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpPost]
        public ActionResult Edit(RegionModel regionModel)
        {
            // check if edited object is valid
            if(!ModelState.IsValid)
            {
                ViewBag.Editing = true;
                return View("Add", regionModel);
            }
            try
            {
                _logic.Update(new RegionDto
                {
                    RegionID = regionModel.RegionID,
                    RegionDescription = regionModel.RegionDescription
                });
                return RedirectToAction("Index");
            }
            catch(EntityFailedValidationException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
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
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }
    }
}