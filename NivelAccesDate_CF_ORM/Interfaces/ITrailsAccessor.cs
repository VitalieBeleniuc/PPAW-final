using LibrarieModeleROWalks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate_CF_ORM.Interfaces
{
    public interface ITrailsAccessor
    {
        List<Trails> GetTrails();
        Trails GetTrail(int id);
        bool AddTrail(Trails trail);
        bool UpdateTrail(Trails trail);
        bool DeleteTrail(int trailId);
    }
}
