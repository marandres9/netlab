using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Logic
{
    public interface ICRUDLogic<T, IDType>
    {
        void Add(T newEntity);
        void Delete(IDType id);
        List<T> GetAll();
        T Get(IDType id); // !!! no va, cambiar por GetDetails
        bool Exists(IDType id);
        void Update(T newEntity);
    }
}
