using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Logic;

namespace TP05_Linq.UI
{
    public class Program
    {
        struct s
        {
            public string name;
            public DateTime date;
        }
        static void Main(string[] args)
        {
            // =========== EJ 1

            //var customersLogic = new CustomersLogic();

            //Console.WriteLine($"{customersLogic.GetCustomer().ContactName}");
            //Console.WriteLine("*****");
            //foreach(var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
            //}

            // =========== EJ 2
            //var productsLogic = new ProductsLogic();
            //foreach(var item in productsLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.ProductID} - {item.ProductName} - {item.UnitsInStock} - {item.UnitPrice}");
            //}
            //Console.WriteLine("*****");
            //foreach(var item in productsLogic.GetAllWithoutStock2())
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.UnitsInStock} - {item.UnitPrice}");
            //}

            //// =========== EJ 3
            //Console.WriteLine("*****");
            //foreach(var item in productsLogic.GetAllInStockWorthMoreThan3())
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.UnitsInStock} - {item.UnitPrice}");
            //}

            // =========== EJ 4
            //Console.WriteLine("*****");
            //foreach(var item in customersLogic.GetAllWhereRegionIs("WA"))
            //{
            //    Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
            //}

            // ===========  EJ 5
            //Console.WriteLine("*******");
            //Console.WriteLine(productsLogic.GetFirstOrDefaultWithID(77).ProductName);

            // =========== EJ 6
            //Console.WriteLine("*******");
            //foreach(var item in customersLogic.GetCustomerNames(true))
            //{
            //    Console.WriteLine($"{item.ToUpper()} - {item.ToLower()}");
            //}

            // =========== EJ 7
            //Console.WriteLine("*******");
            //foreach(var item in customersLogic.GetOrdersFromRegionNewerThan("WA", new DateTime(1997, 1, 1)))
            //{
            //    if(item.OrderDate < new DateTime(1997, 1, 1))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine($"{item.ContactName} - {item.Region} - {item.OrderDate}");
            //        Console.ResetColor();
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{item.ContactName} - {item.Region} - {item.OrderDate}");
            //    }
            //}

            // =========== EJ 8
            //Console.WriteLine("*******");
            //foreach(var item in customersLogic.GetTopThreeFromRegionSortByName("WA"))
            //{
            //    Console.WriteLine($"{item.CustomerID} - {item.ContactName} - {item.Region}");
            //}

            // =========== EJ 9
            //Console.WriteLine("*******");
            //foreach(var item in productsLogic.GetAllSortByName())
            //{
            //    Console.WriteLine($"{item.ProductName}");
            //}

            // =========== EJ 10
            //Console.WriteLine("*******");
            //foreach(var item in productsLogic.GetAllSortByUnitsInStock())
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
            //}

            // =========== EJ 11
            //Console.WriteLine("*******");
            //foreach(var item in productsLogic.GetAllWithCategories())
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.CategoryName}");
            //}

            // =========== EJ 12
            //Console.WriteLine("*******");
            //var prod = productsLogic.GetFirst(productsLogic.GetAllSortByUnitsInStock());
            //Console.WriteLine($"{prod.ProductName}");

            // =========== EJ 13
            //Console.WriteLine("*******");
            //foreach(var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.ContactName} - {customersLogic.GetCustomerOrders(item)}");
            //}
            //Console.WriteLine("*******");
            //foreach(var item in customersLogic.GetAll())
            //{
            //    Console.WriteLine($"{item.ContactName} - {customersLogic.GetOrdersPerCustomer(item)}");
            //}

            var a = new ConsoleApp();
            a.Init();
        }
    }
}
