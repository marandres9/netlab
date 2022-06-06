using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Logic
{
    public interface ICRUDLogic<T>
    {
        void Add(T newEntity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        void Update(T newEntity);

    }
}
