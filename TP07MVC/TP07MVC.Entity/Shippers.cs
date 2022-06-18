namespace TP07MVC.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "Field CompanyName is required.")]
        [StringLength(40, ErrorMessage = "Field CompanyName must be a string with a max length of 40.")]
        public string CompanyName { get; set; }

        [Phone(ErrorMessage = "Field Phone must have a valid phone format")]
        [StringLength(24, ErrorMessage = "Field Phone must be a string with a max length of 24.")]
        public string Phone { get; set; }
    }
}
