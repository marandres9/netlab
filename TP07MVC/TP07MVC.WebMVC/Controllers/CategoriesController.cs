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
    public class CategoriesController: Controller
    {
        private readonly CategoriesLogic _logic = new CategoriesLogic();

        // GET: Categories
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.SearchString = searchString;
            ViewBag.IDSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParam = (sortOrder == "name") ? "name_desc" : "name";
            var list = _logic.GetAll().Select(r => new CategoriesModel(r));

            if(!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(c => c.CategoryName.Contains(searchString)).ToList();
            }
            switch(sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(c => c.CategoryID).ToList();
                    break;
                case "name_desc":
                    list = list.OrderByDescending(c => c.CategoryName).ToList();
                    break;
                case "name":
                    list = list.OrderBy(c => c.CategoryName).ToList();
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
                return View(new CategoriesModel(_logic.GetById(id)));
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
        public ActionResult Add(CategoriesModel categoryModel)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryModel);
            }
            try
            {
                _logic.Add(new Categories
                {
                    CategoryID = categoryModel.CategoryID,
                    CategoryName = categoryModel.CategoryName,
                    Description = categoryModel.Description
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
                var categoryModel = new CategoriesModel(_logic.GetById(id));
                ViewBag.Editing = true;
                return View("Add", categoryModel);
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoriesModel categoryModel)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Editing = true;
                return View("Add", categoryModel);
            }   
            try
            {
                _logic.Update(new Categories
                {
                    CategoryID = categoryModel.CategoryID,
                    CategoryName = categoryModel.CategoryName,
                    Description = categoryModel.Description
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