using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Logic;

namespace TP04_EntityFramework.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShippersLogic shippersLogic = new ShippersLogic();

            foreach(var item in shippersLogic.GetAll()) 
            {
                Console.WriteLine($"{item.ShipperID} - {item.CompanyName}");
            }
        }
    }
}
