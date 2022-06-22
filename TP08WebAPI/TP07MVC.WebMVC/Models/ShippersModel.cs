using System.ComponentModel.DataAnnotations;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;

namespace TP07MVC.WebMVC.Models
{
    public class ShippersModel
    {
        [Display(Name = "ID")]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "Field CompanyName is required.")]
        [StringLength(40, ErrorMessage = "Field CompanyName must be a string with a max length of 40.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(24, ErrorMessage = "Field Phone must be a string with a max length of 24.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public ShippersModel() { }
        public ShippersModel(Shippers shipper)
        {
            ShipperID = shipper.ShipperID;
            CompanyName = shipper.CompanyName;
            Phone = shipper.Phone;
        }
        public ShippersModel(ShipperDto shipper)
        {
            ShipperID = shipper.ShipperID;
            CompanyName = shipper.CompanyName;
            Phone = shipper.Phone;
        }

    }
}