using BusinessLayer.Interfaces;
using System.Collections.Generic;
using NivelAccesDate_CF_ORM;
using LibrarieModeleROWalks;
using BusinessLayer.CoreServices.Interfaces;
using NivelAccesDate_CF_ORM.Interfaces;
using NLog;



namespace BusinessLayer
{
    public class RegionsService : IRegions
    {

        private ICache cacheManager;
        private IRegionsAccessor regionsAccessor;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        // CONSTRUCTORI
        public RegionsService(IRegionsAccessor regionsAccessor, ICache cacheManager)
        {
            this.regionsAccessor = regionsAccessor;
            this.cacheManager = cacheManager;
        }




        // FUNCTIILE
        public List<Regions> GetRegions()
        {
            string key = "regions_list_all";
            List<Regions> regions;

            logger.Debug("OBTINEREA REGIUNILOR DIN DB");

            if (cacheManager.IsSet(key))
            {
                regions = cacheManager.Get<List<Regions>>(key);
            }
            else
            {
                regions = regionsAccessor.GetRegions();
                cacheManager.Set(key, regions);
            }

            return regions;
        }





        public Regions GetRegion(int id)
        {
            Regions region;
            string key = "region_" + id;

            logger.Debug("OBTINEREA UNEI SINGURE REGIUNI DIN DB (DUPA ID)");

            if (cacheManager.IsSet(key))
            {
                region = cacheManager.Get<Regions>(key);
            }
            else
            {
                region = regionsAccessor.GetRegion(id);
                cacheManager.Set(key, region);
            }

            return region;
        }




        public bool AddRegions(Regions region)
        {
            bool result = regionsAccessor.AddRegion(region);
            logger.Debug("ADAUGAREA UNEI REGIUNI NOI");

            if (result)
            {
                cacheManager.Remove("regions_list_all");
            }

            return true;
        }




        public bool UpdateRegions(Regions region)
        {
            bool result = regionsAccessor.UpdateRegion(region);
            logger.Debug("ACTULIZAREA UNEI REGIUNI DIN DB");
            if (result)
            {
                string individual_key = "regions_" + region.Id;
                string list_key = "regions_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }



        public bool DeleteRegions(int regionId)
        {
            bool result = regionsAccessor.DeleteRegion(regionId);
            logger.Debug("STERGEREA UNEI REGIUNI DIN DB");

            if (result)
            {
                string individual_key = "regions_" + regionId;
                string list_key = "regions_list";
                cacheManager.Remove(individual_key);
                cacheManager.RemoveByPattern(list_key);
            }

            return true;
        }

        
    }
}
