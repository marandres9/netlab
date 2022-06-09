using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_EntityFramework.Logic
{
    public interface ICRUDLogic<T, IDType>
    {
        void Add(T newEntity);
        void Delete(IDType id);
        List<T> GetAll();
        T GetById(IDType id);
        void Update(T newEntity);
    }
}
