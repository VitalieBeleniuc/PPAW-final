using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibrarieModeleROWalks;

namespace NivelAccesDate_CF_ORM
{
    public class DB_Context : DbContext, IRegionDBContext, ITrailDBContext
    {
            public DB_Context() : base("name=PPAWConnection")
            {
            //Database.SetInitializer(new DbInitializer());
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB_Context, NivelAccesDate_CF_ORM.Migrations.Configuration>());
            }

            public DbSet<Regions> MyRegions { get; set; }
            public DbSet<Trails> MyTrails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {

            }

        //public System.Data.Entity.DbSet<NivelPrezentare_MVC.Models.TrailViewModel> TrailViewModels { get; set; }
    }
}
