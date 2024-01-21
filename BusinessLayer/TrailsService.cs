using BusinessLayer.Interfaces;
using System.Collections.Generic;
using NivelAccesDate_CF_ORM;
using LibrarieModeleROWalks;
using BusinessLayer.CoreServices.Interfaces;
using NivelAccesDate_CF_ORM.Interfaces;
using NLog;

namespace BusinessLayer
{
    public class TrailsService : ITrails
    {
        private ICache cacheManager;
        private ITrailsAccessor trailsAccessor;
        protected Logger logger = LogManager.GetCurrentClassLogger();


        // CONSTRUCTORI
        public TrailsService(ITrailsAccessor trailsAccessor, ICache cacheManager)
        {
            this.trailsAccessor = trailsAccessor;
            this.cacheManager = cacheManager;
        }




        // FUNCTIILE
        public List<Trails> GetTrails()
        {
            string key = "trails_list_all";
            List<Trails> trails;

            logger.Debug("OBTINEREA CARARILOR DIN DB");

            if (cacheManager.IsSet(key))
            {
                trails = cacheManager.Get<List<Trails>>(key);
            }
            else
            {
                trails = trailsAccessor.GetTrails();
                cacheManager.Set(key, trails);
            }

            return trails;
        }





        public Trails GetTrail(int id)
        {
            Trails trail;
            string key = "trail_" + id;

            logger.Debug("OBTINEREA UNEI SINGURE CARARI DIN DB (DUPA ID)");

            if (cacheManager.IsSet(key))
            {
                trail = cacheManager.Get<Trails>(key);
            }
            else
            {
                trail = trailsAccessor.GetTrail(id);
                cacheManager.Set(key, trail);
            }

            return trail;
        }




        public bool AddTrails(Trails trail)
        {
            bool result = trailsAccessor.AddTrail(trail);
            logger.Debug("ADAUGAREA UNEI CARARI NOI");

            if (result)
            {
                cacheManager.Remove("trails_list_all");
            }

            return true;
        }




        public bool UpdateTrails(Trails trail)
        {
            bool result = trailsAccessor.UpdateTrail(trail);
            logger.Debug("ACTULIZAREA UNEI CARARI DIN DB");
            if (result)
            {
                string individual_key = "trails_" + trail.Id;
                string list_key = "trails_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }



        public bool DeleteTrails(int trailId)
        {
            bool result = trailsAccessor.DeleteTrail(trailId);
            logger.Debug("STERGEREA UNEI CARARI DIN DB");

            if (result)
            {
                string individual_key = "trails_" + trailId;
                string list_key = "trails_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }


    }
}
