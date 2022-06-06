using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Logic
{
    public interface ICRUDLogic<T>
    {
        List<T> GetAll();
    }
}
