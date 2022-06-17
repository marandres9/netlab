using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP07MVC.Entity.ViewModel
{
    public class RegionViewModel
    {
        public RegionViewModel(){ }
        public RegionViewModel(Region entity)
        {
            RegionID = entity.RegionID;
            RegionDescription = entity.RegionDescription;
        }


        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    }
}
