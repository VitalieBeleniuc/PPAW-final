using LibrarieModeleROWalks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NivelPrezentare_MVC.Models
{
    public class TrailViewModel
    {

        public TrailViewModel() { }
        public TrailViewModel(SelectList regions)
        {
            Regions = regions;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LenghtInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public int RegionId { get; set; }

        public SelectList Regions { get; set; }

    }
}