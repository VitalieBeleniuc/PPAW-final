using LibrarieModeleROWalks;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ITrails
    {
        List<Trails> GetTrails();
        Trails GetTrail(int id);
        bool AddTrails(Trails trail);
        bool UpdateTrails(Trails trail);
        bool DeleteTrails(int trailId);
    }
}
