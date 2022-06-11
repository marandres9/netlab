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
        static void Main(string[] args)
        {
            var logic = new CustomersLogic();
            foreach(var item in logic.GetAll())
            {
                Console.WriteLine($"{item.CustomerID} - {item.CompanyName}");

            }
        }
    }
}
