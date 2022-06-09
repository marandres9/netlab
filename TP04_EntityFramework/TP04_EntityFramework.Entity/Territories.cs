using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Entity
{
    [Table("Territories")]
    public partial class Territories
    {
        [Key]
        public string TerritoryID { get; set; }

        [StringLength(50)]
        [Required]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
    }
}
