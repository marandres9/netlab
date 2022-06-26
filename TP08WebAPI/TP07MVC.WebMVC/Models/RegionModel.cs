using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;

namespace TP07MVC.WebMVC.Models
{
    public class RegionModel
    {
        [Required(ErrorMessage = "Field RegionID is required.")]
        [Display(Name = "ID")]
        public int RegionID { get; set; }

        [StringLength(50, ErrorMessage = "Field TerritoryDescription must be a string with a max length of 50.")]
        [Required(ErrorMessage = "Field TerritoryDescription is required.")]
        [Display(Name = "Description")]
        public string RegionDescription { get; set; }

        public RegionModel() { }
        public RegionModel(Region entity)
        {
            RegionID = entity.RegionID;
            RegionDescription = entity.RegionDescription;
        }
        public RegionModel(RegionDto entity)
        {
            RegionID = entity.RegionID;
            RegionDescription = entity.RegionDescription;
        }
    }
}
