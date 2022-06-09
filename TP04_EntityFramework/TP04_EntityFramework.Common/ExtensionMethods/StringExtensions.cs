using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        // A diferencia de int.TryParse(), que devuelve '0' si el string esta vacio, 
        // este metodo devuelve null, si el string es un numero valido, devuelve el numero.
        // Tambien devuelve null si el string no es un numero valido.
        public static int? ParseNullableInt(this string input)
        {
            if(!int.TryParse(input, out int num) || string.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
                return num;
            }
        }

    }
}
