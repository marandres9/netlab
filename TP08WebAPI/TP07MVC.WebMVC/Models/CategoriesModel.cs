using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;

namespace TP07MVC.WebMVC.Models
{
    public class CategoriesModel
    {
        [Display(Name = "ID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Field CategroyName is required.")]
        [StringLength(15, ErrorMessage = "Field CategroyName must be a string with a max length of 50.")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public CategoriesModel() { }
        public CategoriesModel(Categories cat)
        {
            CategoryID = cat.CategoryID;
            CategoryName = cat.CategoryName;
            Description = cat.Description;
        }
        public CategoriesModel(CategoryDto cat)
        {
            CategoryID = cat.CategoryID;
            CategoryName = cat.CategoryName;
            Description = cat.Description;
        }
    }
}