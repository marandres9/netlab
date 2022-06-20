using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Common.Exceptions
{
    public class IDNotFoundException: Exception
    {
        public IDNotFoundException() { }
        public IDNotFoundException(string msg) : base(msg)
        { }
        public IDNotFoundException(string msg, Exception innerException) : base(msg, innerException)
        { }
    }
}
