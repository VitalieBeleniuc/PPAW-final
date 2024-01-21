using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModeleROWalks
{
    [Serializable]
    public class Trails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LenghtInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public int RegionId { get; set; }

        public virtual Regions Region { get; set; }

        public Trails()
        { }
    }
}
