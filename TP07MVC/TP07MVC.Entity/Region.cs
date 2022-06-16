using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity
{
    [Table("Region")]
    public partial class Region
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        [Required(ErrorMessage = "Field RegionDescription is required.")]
        [StringLength(50, ErrorMessage = "Field RegionDescription must be a string with a max length of 50.")]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
