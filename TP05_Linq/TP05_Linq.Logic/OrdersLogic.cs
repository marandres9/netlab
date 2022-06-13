using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Entities;

namespace TP05_Linq.Logic
{
    public class OrdersLogic: BaseLogic
    {
        public int GetCustomerOrders(Customers customer)
        {
            return (from order in _context.Orders
                    where order.CustomerID == customer.CustomerID
                    select order).Count();
        }
    }
}
