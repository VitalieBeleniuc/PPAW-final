using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Interfaces;
using LibrarieModeleROWalks;
using NivelAccesDate_CF_ORM;
using NivelPrezentare_MVC.Models;
using NLog;

namespace NivelPrezentare_MVC.Controllers
{
    public class RegionsController : Controller
    {

        private IRegions regionsService;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public RegionsController(IRegions regionsService)
        {
            this.regionsService = regionsService;
        }

        // GET: Regions
        public ActionResult Index()
        {
            List<RegionViewModel> regionsViewModel = new List<RegionViewModel>();

            List<Regions> regions = regionsService.GetRegions();
            if (regions is null)
            {
                logger.Error("REGIUNILE NU POT FI GASITE");
                return View(regionsViewModel);
            }


            foreach (Regions region in regions)
            {
                RegionViewModel regionViewModel = new RegionViewModel()
                {
                    Id = region.Id,
                    Code = region.Code,
                    RegionName = region.RegionName,
                    RegionImageUrl = region.RegionImageUrl,
                    IsActive = region.IsActive
                };

                regionsViewModel.Add(regionViewModel);
            }
            return View(regionsViewModel);
        }



        // GET: Regions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions region = regionsService.GetRegion(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }

            RegionViewModel regionViewModel = new RegionViewModel()
            {
                Id = region.Id,
                Code = region.Code,
                RegionName = region.RegionName,
                RegionImageUrl = region.RegionImageUrl,
                IsActive = region.IsActive
            };

            return View(regionViewModel);
        }







        // GET: Regions/Create
        public ActionResult Create()
        {
            RegionViewModel model = new RegionViewModel();
            return View(model);
        }

        // POST: Regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionViewModel regionViewModel)
        {
            if (ModelState.IsValid)
            {
                Regions region = new Regions()
                {
                    Id = regionViewModel.Id,
                    Code = regionViewModel.Code,
                    RegionName = regionViewModel.RegionName,
                    RegionImageUrl = regionViewModel.RegionImageUrl,
                    IsActive = regionViewModel.IsActive
                };

                regionsService.AddRegions(region);

                return RedirectToAction("Index");
            }

            return View(regionViewModel);
        }








        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions region = regionsService.GetRegion(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }

            RegionViewModel regionViewModel = new RegionViewModel()
            {
                Id = region.Id,
                Code = region.Code,
                RegionName = region.RegionName,
                RegionImageUrl = region.RegionImageUrl,
                IsActive = region.IsActive
            };

            return View(regionViewModel);
        }





        // POST: Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,RegionName,RegionImageUrl,IsActive")] RegionViewModel regionViewModel)
        {
            if (ModelState.IsValid)
            {
                Regions region = new Regions()
                {
                    Id = regionViewModel.Id,
                    Code = regionViewModel.Code,
                    RegionName = regionViewModel.RegionName,
                    RegionImageUrl = regionViewModel.RegionImageUrl,
                    IsActive = regionViewModel.IsActive
                };

                regionsService.UpdateRegions(region);

                return RedirectToAction("Index");
            }
            return View(regionViewModel);
        }






        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions region = regionsService.GetRegion(id.Value);
            if (region == null)
            {
                return HttpNotFound();
            }
            RegionViewModel regionViewModel = new RegionViewModel()
            {
                Id = region.Id,
                Code = region.Code,
                RegionName = region.RegionName,
                RegionImageUrl = region.RegionImageUrl,
                IsActive = region.IsActive
            };

            return View(regionViewModel);
        }



        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regionsService.DeleteRegions(id);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
