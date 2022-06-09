using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Common.Exceptions
{
    public class EntityFailedValidationException: Exception
    {
        public EntityFailedValidationException() { }
        public EntityFailedValidationException(string msg) : base(msg)
        { }
        public EntityFailedValidationException(string msg, Exception innerException) : base(msg, innerException)
        { }
    }
}
