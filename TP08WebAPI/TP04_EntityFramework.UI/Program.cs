using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Logic;

namespace TP07MVC.UI
{
    public class Test
    {
        public int A { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp();
            app.Init();

            //var ter = new TerritoriesLogic();
            //foreach(var t in ter.GetAll())
            //{
            //    Console.WriteLine($"{t.TerritoryID}");
            //}

            //ter.Add(new Territories { TerritoryID = "98104" });
        }
    }
}
