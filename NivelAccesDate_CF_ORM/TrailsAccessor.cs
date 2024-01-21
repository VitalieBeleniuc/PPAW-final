using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using NLog;
using LibrarieModeleROWalks;
using NivelAccesDate_CF_ORM.Interfaces;
using System.Data.Entity.Migrations;

namespace NivelAccesDate_CF_ORM
{
    public class TrailsAccessor : ITrailsAccessor
    {

        private DB_Context db;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public TrailsAccessor(ITrailDBContext db)
        {
            this.db = (DB_Context)db;
        }


        public List<Trails> GetTrails()
        {
            List<Trails> trails;

            try
            {
                trails = db.MyTrails.AsNoTracking().ToList();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "EROARE: NU S-AU OBTINUT DATE DIN DB");
                return null;
            }

            return trails;
        }



        public Trails GetTrail(int id)
        {
            Trails trail = db.MyTrails.AsNoTracking().FirstOrDefault(localTrail => localTrail.Id == id);
            return trail;
        }



        public bool AddTrail(Trails trail)
        {
            db.MyTrails.Add(trail);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;
        }




        public bool UpdateTrail(Trails trail)
        {
            db.MyTrails.AddOrUpdate(trail);
            //db.Entry(trail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailExists(trail.Id))
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

        public bool DeleteTrail(int trailId)
        {
            Trails trail = db.MyTrails.Find(trailId);

            db.MyTrails.Remove(trail);
            db.SaveChanges();

            return true;
        }

        private bool TrailExists(int id)
        {
            return db.MyTrails.Count(e => e.Id == id) > 0;
        }


        // method injection
        public void SetDependency(DB_Context db)
        {
            this.db = (DB_Context)db;
        }

        //property injection
        public ITrailDBContext DbContextProperty
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


