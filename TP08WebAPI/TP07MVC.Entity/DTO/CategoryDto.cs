using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP07MVC.Entity.DTO
{
    public class CategoryDto
    {
        [Key]
        [Display(Name = "ID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Field CategroyName is required.")]
        [StringLength(15, ErrorMessage = "Field CategroyName must be a string with a max length of 50.")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public CategoryDto() { }
        public CategoryDto(Categories cat)
        {
            CategoryID = cat.CategoryID;
            CategoryName = cat.CategoryName;
            Description = cat.Description;
        }
    }
}
