using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Common.Exceptions
{
    public class IDAlreadyTakenException: Exception
    {
        public IDAlreadyTakenException() { }
        public IDAlreadyTakenException(string msg) : base(msg)
        { }
        public IDAlreadyTakenException(string msg, Exception innerException) : base(msg, innerException)
        { }
    }
}
