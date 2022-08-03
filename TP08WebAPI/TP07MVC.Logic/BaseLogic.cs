using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Data;

namespace TP07MVC.Logic
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
