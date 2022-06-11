using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Entities;

namespace TP05_Linq.Logic
{
    public class CustomersLogic: BaseLogic
    {
        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
