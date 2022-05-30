using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO.src
{
    public class Omnibus: TransportePublico
    {
        // La capacidad maxiama del vehiculo
        private const int _capacidadMaxima = 100;

        // Campo estatico, se incrementa en el constructor y se asigna como 
        // identificador (Id) de cada vehiculo
        // Se implementa en las clases derivadas para que no se comparta
        // entre distintos tipo de vehiculos.
        private static int s_count = 0;
        public int Id { get; }

        public Omnibus(int pasajeros) : base(_capacidadMaxima, pasajeros)
        {
            s_count++;
            Id = s_count;
        }

        // Implementacion de los metodos de la clase base
        override public void InformarEstado()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Omnnibus {Id} - Capacidad: {Pasajeros}/{CapacidadMaxima} - En movimineto: {SeMueve}");
            Console.ResetColor();
        }

        override public void Avanzar()
        {
            // Se debe actualizar el estado del vehiculo
            SeMueve = true;
            Console.WriteLine($"Omnibus {Id} avanza con {Pasajeros} pasajeros - ({Pasajeros}/{CapacidadMaxima})");
        }

        // Se crea un nuevo metodo publico que llama al metodo protegido de la clase base,
        // no hace falta actualizar el estado
        override public void Detenerse()
        {
            base.Detenerse();
            Console.WriteLine($"Omnibus {Id} se detuvo con {Pasajeros} pasajeros - ({Pasajeros}/{CapacidadMaxima})");
        }
    }
}
