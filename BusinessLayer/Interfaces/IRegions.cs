using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModeleROWalks;

namespace BusinessLayer.Interfaces
{
    public interface IRegions
    {
        List<Regions> GetRegions();
        Regions GetRegion(int id);
        bool AddRegions(Regions region);
        bool UpdateRegions(Regions region);
        bool DeleteRegions(int regionId);
    }
}
