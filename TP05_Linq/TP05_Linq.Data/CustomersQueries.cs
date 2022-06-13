using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Entities;

namespace TP05_Linq.Data
{
    public class CustomersQueries
    {
        public static IEnumerable<Customers> GetWhere(Func<Customers, bool> predicate)
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.Where(predicate);
            }
        }
    }
}
