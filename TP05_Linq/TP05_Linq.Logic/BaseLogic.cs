using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05Linq.Data;

namespace TP05Linq.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext _context;
        public BaseLogic()
        {
            _context = new NorthwindContext();
        }
        public BaseLogic(NorthwindContext context)
        {
            _context = context;
        }
    }
}
