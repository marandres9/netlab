using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Logic
{
    public interface ICRUDLogic<TDto, TId>
    {
        TDto Add(TDto newEntity);
        void Delete(TId id);
        List<TDto> GetAll();
        bool Exists(TId id);
        TDto Update(TDto newEntity);
    }
}
