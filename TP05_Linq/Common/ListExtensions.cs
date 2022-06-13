using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ListExtensions
    {
        public static T GetFirst<T>(this List<T> list)
        {
            return list.FirstOrDefault();
        }
    }
}
