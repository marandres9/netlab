using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Data;

namespace TP04_EntityFramework.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }
        // used for mock tests
        public BaseLogic(NorthwindContext context)
        {
            _context = context;
        }
    }
}
