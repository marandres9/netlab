using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02_Exceptions_ExtMethods_Testing.ExtensionMethods
{
    public static class DoubleExtensions
    {
        public static bool IsNegative(this double num)
        {
            return num < 0;
        }
    }
}
