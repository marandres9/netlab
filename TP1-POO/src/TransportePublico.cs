using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO.src
{
    public abstract class TransportePublico
    {
        // La cantidad de pasajeros que se encuentran dentro del transporte
        private int _pasajeros;
        // Expone getters y setters. El setter verifica que la cantidad sea adecuada
        public int Pasajeros
        {
            set
            {
                if(value < 0 || value > CapacidadMaxima)
                {
                    throw new ArgumentOutOfRangeException(nameof(Pasajeros), $"La capacidad max de este vehiculo es {CapacidadMaxima}, utilizando {Pasajeros}");
                }
                else
                {
                    _pasajeros = value;
                }
            }
            get { return _pasajeros; }
        }

        // Capacidad max que puede transportar el vehiculo
        // Solo se puede settear dentro de la clase, en este caso en el constructor
        // ya que depende del tipo de transporte
        public int CapacidadMaxima { get; private set; }
        // Almacena el estado de movimiento del vehiculo
        public bool SeMueve { get; set; }

        public TransportePublico(int capacidadMaxima, int pasajeros)
        {
            CapacidadMaxima = capacidadMaxima;
            Pasajeros = pasajeros;
            SeMueve = false;
        }

        // Metodos abstractos
        public abstract void InformarEstado();

        // En la implementacion se debe actualizar SeMueve, que indica el estado de movimiento
        // del vehiculo, ya que se inicializa siempre como False
        public abstract void Avanzar();

        // Cumple la funcion inversa de Avanzar()
        // Alternativa a un metodo abstracto: la clase derivada puede exponer un metodo publico
        // que llame a este metodo pasando el tipo de transporte. De esta manera la clase derivada
        // no necesita actualizar el estado de movimiento del vehiculo.
        public virtual void Detenerse()
        {
            SeMueve = false;
        }
    }
}
