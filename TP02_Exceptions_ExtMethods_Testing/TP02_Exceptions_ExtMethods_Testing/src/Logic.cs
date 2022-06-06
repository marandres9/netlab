using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP02_Exceptions_ExtMethods_Testing.Exceptions;
using TP02_Exceptions_ExtMethods_Testing.ExtensionMethods;

namespace TP02_Exceptions_ExtMethods_Testing
{
    public class Logic
    {
        public static double Divide(double a, double b)
        {
            // hay que lanzar la excepcion de forma manual ya que la
            // la excepcion DivideByZeroException solo se lanza al dividir 
            // numeros enteros. Si el divisor es 0 y no se lanza la excepcion 
            // de forma manual, esta funcion devuelve infinito.
            if(b == 0)
            {
                throw new DivideByZeroException("Solo Chuck Norris divide por cero!");
            }

            return a / b;
        }

        public static double SquareRoot(double num)
        {
            //if(num < 0)
            // uso metodo extendido de la clase Double
            if(num.IsNegative())
            {
                throw new NegataiveRadicandException("A nadie le gusta los numeros imaginarios!");
            }
            return Math.Sqrt(num);
        }

        public static double ParseUserInput(string input)
        {
            double num;

            if(double.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                throw new InvalidInputException("Seguro Ingreso una letra o no ingreso nada!");
            }
        }

        public static void ThrowException()
        {
            throw new Exception();
        }
    }
}
