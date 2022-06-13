using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Data;
using TP05_Linq.Entities;
using TP05_Linq.Entities.DTO;

namespace TP05_Linq.Logic
{
    public class CustomersLogic: BaseLogic
    {

        private IEnumerable<Customers> GetWhere(Func<Customers, bool> predicate)
        {
            return _context.Customers.Where(predicate);
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customers GetFirst()
        {
            return _context.Customers.First(c => c.Region != null);
        }

        public List<Customers> GetFromRegion(string region)
        {
            //var query = from customer in _context.Customers
            //            where customer.Region == region
            //            select customer;
            //return query.ToList();
            return GetWhere(c => c.Region == region).ToList();
        }

        public List<string> GetCustomerNames()
        {
            var query = from customers in _context.Customers
                        select customers.ContactName;
            return query.ToList();
        }

        public List<DTOCustomer_Order> GetOrdersFromRegionNewerThan(string region, DateTime date)
        {
            var query = from cust in _context.Customers
                        join order in _context.Orders on cust.CustomerID equals order.CustomerID
                        where cust.Region.Equals(region) && order.OrderDate > date
                        orderby order.OrderDate
                        select new DTOCustomer_Order { ContactName = cust.ContactName, Region = cust.Region, OrderDate = order.OrderDate };
            return query.ToList();
        }

        public List<Customers> GetFilterByDate()
        {
            var query = from order in _context.Orders
                        where order.OrderDate < new DateTime(1997, 1, 1)
                        join customer in (from cust in _context.Customers
                                          where cust.Region.Equals("WA")
                                          select cust)
                        on order.CustomerID equals customer.CustomerID
                        select customer;

            return query.ToList();
        }

        public List<Customers> GetTopThreeFromRegion(string region)
        {
            return GetWhere(c => c.Region == region).Take(3).ToList();
        }

        public int GetCustomerOrders(Customers customer)
        {
            return _context.Customers.First(c => c.CustomerID.Equals(customer.CustomerID)).Orders.Count();
        }

        public int GetOrdersPerCustomer(Customers customer)
        {
            return (from order in _context.Orders
                    where order.CustomerID == customer.CustomerID
                    select order).Count();
        }

        public int GetOrdersPerCustomer2(Customers customer)
        {
            return _context.Orders.Where(o => o.CustomerID == customer.CustomerID).Count();
        }
    }
}
