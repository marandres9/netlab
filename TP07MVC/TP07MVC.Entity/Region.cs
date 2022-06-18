using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity.ViewModel;

namespace TP07MVC.Entity
{
    [Table("Region")]
    public partial class Region
    {
        public Region() { }
        public Region(RegionViewModel model)
        {
            RegionID = model.RegionID;
            RegionDescription = model.RegionDescription;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Field RegionID is required.")]
        public int RegionID { get; set; }

        [Required(ErrorMessage = "Field RegionDescription is required.")]
        [StringLength(50, ErrorMessage = "Field RegionDescription must be a string with a max length of 50.")]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
