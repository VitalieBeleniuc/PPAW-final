using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using LibrarieModeleROWalks;
using NivelAccesDate_CF_ORM.Interfaces;
using System.Data.Entity.Migrations;

namespace NivelAccesDate_CF_ORM
{
    public class RegionsAccessor : IRegionsAccessor
    {

        private DB_Context db;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public RegionsAccessor(IRegionDBContext db)
        {
            this.db = (DB_Context)db;
        }


        public List<Regions> GetRegions()
        {
            List<Regions> regions;

            try
            {
                // ACTUALIZAT PENTRU SOFT DELETE LAB10
                regions = db.MyRegions.AsNoTracking().Where(r => r.IsActive == true).ToList();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "EROARE: NU S-AU OBTINUT DATE DIN DB");
                return null;
            }

            return regions;
        }



        public Regions GetRegion(int id)
        {
            try
            {
                // ACTUALIZAT PENTRU SOFT DELETE LAB10
                Regions region = db.MyRegions.AsNoTracking().Where(r => r.IsActive).FirstOrDefault(localRegion => localRegion.Id == id);
                return region;
            }
            catch (Exception exception)
            {
                logger.Error(exception, "EROARE: NU S-AU OBTINUT DATE DIN DB");
                return null;
            }
        }



        public bool AddRegion(Regions region)
        {
            db.MyRegions.Add(region);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;
        }




        public bool UpdateRegion(Regions region)
        {
            region.IsActive = true;
            db.Entry(region).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(region.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }



        public bool DeleteRegion(int regionId)
        {
            Regions region = db.MyRegions.Find(regionId);

            if (region != null)
            {
                // In loc de stergere fizica regiunea e doar marcata (LAB 1O SOFFT DELETE)
                region.IsActive = false;

                // ACTUALIZARE
                //db.Entry(region).State = EntityState.Modified;
                db.MyRegions.AddOrUpdate(region);
                db.SaveChanges();

                return true;
            }

            return false;
        }



        private bool RegionExists(int id)
        {
            return db.MyRegions.Count(e => e.Id == id) > 0;
        }


        // method injection
        public void SetDependency(DB_Context db)
        {
            this.db = (DB_Context)db;
        }

        //property injection
        public IRegionDBContext DbContextProperty
        {
            set
            {
                this.db = (DB_Context)value;
            }
            get
            {
                if (db == null)
                {
                    throw new Exception("DbContext is not initialized");
                }
                else
                {
                    return db;
                }
            }
        }
        
    }
}


