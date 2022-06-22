using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity;
using TP07MVC.Logic;
using TP07MVC.WebMVC.Models;

namespace TP07MVC.WebMVC.Controllers
{
    public class ShippersController: Controller
    {
        private readonly ShippersLogic _logic = new ShippersLogic();
        // GET: Shippers
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SearchString = searchString;
            ViewBag.IDSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParam = (sortOrder == "name") ? "name_desc" : "name";
            var list = _logic.GetAll().Select(r => new ShippersModel(r));

            if(!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.CompanyName.Contains(searchString)).ToList();
            }
            switch(sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(c => c.ShipperID).ToList();
                    break;
                case "name_desc":
                    list = list.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "name":
                    list = list.OrderBy(c => c.CompanyName).ToList();
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
                return View(new ShippersModel(_logic.Get(id)));
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
        public ActionResult Add(ShippersModel shippersModel)
        {
            if(!ModelState.IsValid)
            {
                return View(shippersModel);
            }
            try
            {
                _logic.Add(new Shippers
                {
                    ShipperID = shippersModel.ShipperID,
                    CompanyName = shippersModel.CompanyName,
                    Phone = shippersModel.Phone
                });
                return RedirectToAction("Index");
            }
            catch(EntityFailedValidationException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var shippersModel = _logic.Get(id);
                ViewBag.Editing = true;
                return View("Add", shippersModel);
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpPost]
        public ActionResult Edit(ShippersModel shippersModel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Editing = true;
                return View("Add", shippersModel);
            }
            try
            {
                _logic.Update(new Shippers
                {
                    ShipperID = shippersModel.ShipperID,
                    CompanyName = shippersModel.CompanyName,
                    Phone = shippersModel.Phone
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