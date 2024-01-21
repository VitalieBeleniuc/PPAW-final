using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using LibrarieModeleROWalks;
using NivelAccesDate_CF_ORM;
using NivelPrezentare_MVC.Models;
using NLog;

namespace NivelPrezentare_MVC.Controllers
{
    public class TrailsController : Controller
    {
        private ITrails trailsService;
        private IRegions regionsService;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public TrailsController(ITrails trailsService, IRegions regionsService)
        {
            this.trailsService = trailsService;
            this.regionsService = regionsService;
        }

        // GET: Trails
        public ActionResult Index()
        {
            List<TrailViewModel> trailsViewModel = new List<TrailViewModel>();

            List<Trails> trails = trailsService.GetTrails();
            if (trails is null)
            {
                logger.Error("CARARILE NU POT FI GASITE");

                return View(trailsViewModel);
            }


            foreach (Trails trail in trails)
            {
                TrailViewModel trailViewModel = new TrailViewModel()
                {
                    Id = trail.Id,
                    Name = trail.Name,
                    Description = trail.Description,
                    LenghtInKm = trail.LenghtInKm,
                    WalkImageUrl = trail.WalkImageUrl,
                    RegionId = trail.RegionId
                };

                trailsViewModel.Add(trailViewModel);
            }
            return View(trailsViewModel);
        }



        // GET: Trails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trails trail = trailsService.GetTrail(id.Value);
            if (trail == null)
            {
                return HttpNotFound();
            }

            TrailViewModel trailViewModel = new TrailViewModel()
            {
                Id = trail.Id,
                Name = trail.Name,
                Description = trail.Description,
                LenghtInKm = trail.LenghtInKm,
                WalkImageUrl = trail.WalkImageUrl,
                RegionId = trail.RegionId
            };

            return View(trailViewModel);
        }







        // GET: Trails/Create
        public ActionResult Create()
        {
            SelectList regions = new SelectList(regionsService.GetRegions(), "Id", "RegionName");
            TrailViewModel model = new TrailViewModel(regions);
            return View(model);
        }

        // POST: Trails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailViewModel trailViewModel)
        {

            Trails trail = new Trails();
            if (ModelState.IsValid)
            {
                trail = new Trails()
                {
                    Id = trailViewModel.Id,
                    Name = trailViewModel.Name,
                    Description = trailViewModel.Description,
                    LenghtInKm = trailViewModel.LenghtInKm,
                    WalkImageUrl = trailViewModel.WalkImageUrl, 
                    RegionId = trailViewModel.RegionId
                };

                trailsService.AddTrails(trail);

                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(regionsService.GetRegions(), "Id", "RegionName", trail.RegionId);
            return View(trailViewModel);
        }








        // GET: Trails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trails trail = trailsService.GetTrail(id.Value);
            
            if (trail == null)
            {
                return HttpNotFound();
            }

            TrailViewModel trailViewModel = new TrailViewModel()
            {
                Id = trail.Id,
                Name = trail.Name,
                Description = trail.Description,
                LenghtInKm = trail.LenghtInKm,
                WalkImageUrl = trail.WalkImageUrl,
                RegionId = trail.RegionId
            };

            ViewBag.RegionId = new SelectList(regionsService.GetRegions(), "Id", "RegionName", trail.RegionId);
            return View(trailViewModel);
        }





        // POST: Trails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,LenghtInKm,WalkImageUrl,RegionId")] TrailViewModel trailViewModel)
        {
            Trails trail = new Trails();
            if (ModelState.IsValid)
            {
                trail = new Trails()
                {
                    Id = trailViewModel.Id,
                    Name = trailViewModel.Name,
                    Description = trailViewModel.Description,
                    LenghtInKm = trailViewModel.LenghtInKm,
                    WalkImageUrl = trailViewModel.WalkImageUrl,
                    RegionId = trailViewModel.RegionId
                };

                trailsService.UpdateTrails(trail);

                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(regionsService.GetRegions(), "Id", "RegionName", trail.RegionId);
            return View(trailViewModel);
        }






        // GET: Trails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trails trail = trailsService.GetTrail(id.Value);
            if (trail == null)
            {
                return HttpNotFound();
            }
            TrailViewModel trailViewModel = new TrailViewModel()
            {
                Id = trail.Id,
                Name = trail.Name,
                Description = trail.Description,
                LenghtInKm = trail.LenghtInKm,
                WalkImageUrl = trail.WalkImageUrl,
                RegionId = trail.RegionId
            };

            return View(trailViewModel);
        }



        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trailsService.DeleteTrails(id);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
