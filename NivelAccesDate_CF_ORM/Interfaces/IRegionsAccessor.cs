using LibrarieModeleROWalks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate_CF_ORM.Interfaces
{
    public interface IRegionsAccessor
    {
        List<Regions> GetRegions();
        Regions GetRegion(int id);
        bool AddRegion(Regions region);
        bool UpdateRegion(Regions region);
        bool DeleteRegion(int regionId);
    }
}
