using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModeleROWalks
{
    [Serializable]
    public class Regions
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RegionName { get; set; }
        public string RegionImageUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Trails> Trailss { get; set; }
        public Regions()
        {
            this.Trailss = new List<Trails>();
        }
    }
}
