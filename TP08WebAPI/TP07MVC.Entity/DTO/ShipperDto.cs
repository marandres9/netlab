using System.ComponentModel.DataAnnotations;

namespace TP07MVC.Entity.DTO
{
    public class ShipperDto
    {
        [Key]
        [Display(Name = "ID")]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "Field CompanyName is required.")]
        [StringLength(40, ErrorMessage = "Field CompanyName must be a string with a max length of 40.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(24, ErrorMessage = "Field Phone must be a string with a max length of 24.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public ShipperDto() { }
        public ShipperDto(Shippers shipper)
        {
            ShipperID = shipper.ShipperID;
            CompanyName = shipper.CompanyName;
            Phone = shipper.Phone;
        }
    }
}
