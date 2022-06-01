using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02_Exceptions_ExtMethods_Testing.Exceptions
{
    public class InvalidInputException: Exception
    {
        public InvalidInputException() { }
        public InvalidInputException(string msg) : base(msg)
        { }
    }

    // El radicando (radicand) es el numero dentro de una raiz
    public class NegataiveRadicandException: Exception
    {
        public NegataiveRadicandException() { }
        public NegataiveRadicandException(string msg) : base(msg)
        { }
    }
}
