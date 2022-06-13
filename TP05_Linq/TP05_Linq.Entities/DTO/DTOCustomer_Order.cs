using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05Linq.Entities.DTO
{
    public class DTOCustomer_Order
    {
        public string ContactName { get; set; }
        public string Region { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
