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
    public class CategoriesController: Controller
    {
        private readonly CategoriesLogic _logic = new CategoriesLogic();

        // GET: Categories
        public ActionResult Index()
        {
            return View(_logic.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Categories category)
        {
            try
            {
                _logic.Add(category);
                return RedirectToAction("Index");
            }
            catch(EntityFailedValidationException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        public ActionResult Update(int id)
        {
            try
            {
                return View("Add", _logic.GetById(id));
            }
            catch(IDNotFoundException ex)
            {
                return View("~/Views/Shared/Exception.cshtml", ex);
            }
        }

        [HttpPost]
        public ActionResult Update(Categories category)
        {
            try
            {
                _logic.Update(category);
                return RedirectToAction("Index");
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