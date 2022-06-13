using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Entities;

namespace TP05_Linq.Data
{
    public class ProductsQueries
    {
        public static List<Products> GetAllWhere(Func<Products, bool> predicate)
        {
            using(var context = new NorthwindContext())
            {
                return context.Products.Where(predicate).ToList();
            }
        }
    }
}
