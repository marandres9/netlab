namespace TP07MVC.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TP07MVC.Entity.DTO;

    public partial class Categories
    {
        [Key]
        [Display(Name = "ID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Field CategroyName is required.")]
        [StringLength(15, ErrorMessage = "Field CategroyName must be a string with a max length of 50.")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public Categories() { }
        public Categories(CategoryDto cat)
        {
            CategoryID = cat.CategoryID;
            CategoryName = cat.CategoryName;
            Description = cat.Description;
        }
    }
}
