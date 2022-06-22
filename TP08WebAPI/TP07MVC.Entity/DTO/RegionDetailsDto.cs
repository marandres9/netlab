using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity.DTO
{
    public class RegionDetailsDto
    {
        [Display(Name = "ID")]
        public int RegionID { get; set; }
        [Display(Name = "Description")]
        public string RegionDescription { get; set; }
        [Display(Name = "Territories")]
        public List<string> Territories { get; set; }
    }
}
