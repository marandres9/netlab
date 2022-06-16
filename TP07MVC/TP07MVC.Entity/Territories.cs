using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity
{
    [Table("Territories")]
    public partial class Territories
    {
        [Key]
        public string TerritoryID { get; set; }

        [StringLength(50, ErrorMessage = "Field TerritoryDescription must be a string with a max length of 50.")]
        [Required(ErrorMessage = "Field TerritoryDescription is required.")]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}
