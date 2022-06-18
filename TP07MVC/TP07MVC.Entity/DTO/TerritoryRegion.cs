using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity.DTO
{
    public class TerritoryRegion
    {
        [Display(Name = "ID")]
        public string TerritoryID { get; set; }
        [Display(Name = "Description")]
        public string TerritoryDescription { get; set; }
        [Display(Name = "Region")]
        public string RegionDescription { get; set; }

    }
}
