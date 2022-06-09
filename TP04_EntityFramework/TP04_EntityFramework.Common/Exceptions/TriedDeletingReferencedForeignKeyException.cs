using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Common.Exceptions
{
    public class TriedDeletingReferencedForeignKeyException: Exception
    {
        public TriedDeletingReferencedForeignKeyException() { }
        public TriedDeletingReferencedForeignKeyException(string msg) : base(msg)
        { }
        public TriedDeletingReferencedForeignKeyException(string msg, Exception innerException) : base(msg, innerException)
        { }
    }
}
