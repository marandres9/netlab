using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05Linq.Logic;

namespace TP05Linq.UI
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
            var consoleApp = new ConsoleApp();
            consoleApp.Init();
        }
    }
}
