using LibrarieModeleROWalks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivelPrezentare_MVC.Models
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RegionName { get; set; }
        public string RegionImageUrl { get; set; }
        public bool IsActive { get; set; }

    }
}