using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity.DTO
{
    public class RegionDto
    {

        [Required(ErrorMessage = "Field RegionID is required.")]
        [Display(Name = "ID")]
        public int RegionID { get; set; }

        [Required(ErrorMessage = "Field RegionDescription is required.")]
        [StringLength(50, ErrorMessage = "Field RegionDescription must be a string with a max length of 50.")]
        [Display(Name = "Description")]
        public string RegionDescription { get; set; }

        public RegionDto() { }
        public RegionDto(Region reg)
        {
            RegionID = reg.RegionID;
            RegionDescription = reg.RegionDescription;
        }
    }
}
