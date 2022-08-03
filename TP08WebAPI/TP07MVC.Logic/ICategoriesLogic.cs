using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;

namespace TP07MVC.Logic
{
    public interface ICategoriesLogic: ICRUDLogic<Categories, CategoryDto, int>
    {
        CategoryDto GetDetails(int id);
        List<CategoryDto> GetList(string filterString);
    }
}
