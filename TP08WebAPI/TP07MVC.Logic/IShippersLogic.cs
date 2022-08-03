using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;

namespace TP07MVC.Logic
{
    public interface IShippersLogic: ICRUDLogic<Shippers, ShipperDto, int>
    {
        ShipperDto GetDetails(int id);
    }
}
