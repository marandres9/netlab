using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO.src
{
    public class Program
    {
        // El programa crea listas de transportes publicos y modifica los 
        // estados de algunos, luego los muestra en la consola.
        static void Main(string[] args)
        {

            var transportes = new List<TransportePublico>
            {
                new Taxi(1),
                new Taxi(4),
                new Taxi(1),
                new Taxi(2),
                new Taxi(3),
                new Omnibus(99),
                new Omnibus(27),
                new Omnibus(7),
                new Omnibus(64),
                new Omnibus(81),
            };

            transportes[1].Avanzar();
            transportes[3].Avanzar();
            transportes[5].Avanzar();
            transportes[7].Avanzar();
            transportes[9].Avanzar();
            transportes[5].Detenerse();

            Console.WriteLine();

            foreach(var transporte in transportes)
            {
                transporte.InformarEstado();
            }
        }
    }
}
