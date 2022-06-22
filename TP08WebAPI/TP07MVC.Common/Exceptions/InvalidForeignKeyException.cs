using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Common.Exceptions
{
    public class InvalidForeignKeyException: Exception
    {
        public InvalidForeignKeyException() { }
        public InvalidForeignKeyException(string msg) : base(msg)
        { }
        public InvalidForeignKeyException(string msg, Exception innerException) : base(msg, innerException)
        { }
    }
}
