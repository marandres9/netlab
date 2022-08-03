using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Logic
{
    public interface ICRUDLogic<TModel, TDto, TId>
    {
        TDto Add(TDto newEntity);
        void Delete(TId id);
        TDto Get(TId id);
        IEnumerable<TDto> GetAll();
        List<TDto> GetList();
        List<TDto> GetList(Func<TModel, bool> filter);
        bool Exists(TId id);
        TDto Update(TDto newEntity);
    }
}
