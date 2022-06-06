using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Entity;

namespace TP04_EntityFramework.Logic
{
    public class ShippersLogic: BaseLogic, ICRUDLogic<Shippers>
    {
        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }
    }
}
