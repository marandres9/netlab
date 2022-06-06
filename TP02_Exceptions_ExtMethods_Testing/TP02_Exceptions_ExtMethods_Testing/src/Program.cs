using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02_Exceptions_ExtMethods_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // la clase presentacion se encarga de manejar la consola
            // y las interacciones con el usuario
            var program = new Presentacion();
            program.Init();
        }
    }
}
