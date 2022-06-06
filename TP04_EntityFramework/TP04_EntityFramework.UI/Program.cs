using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Entity;
using TP04_EntityFramework.Logic;

namespace TP04_EntityFramework.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShippersLogic shippersLogic = new ShippersLogic();

            //shippersLogic.Add(new Shippers { CompanyName = "new Company", Phone = "123-456" });

            foreach(var item in shippersLogic.GetAll()) 
            {
                Console.WriteLine($"{item.ShipperID} - {item.CompanyName} - {item.Phone}");
            }
        }
    }
}
