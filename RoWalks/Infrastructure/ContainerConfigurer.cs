using BusinessLayer.Interfaces;
using BusinessLayer;
using NivelAccesDate_CF_ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using BusinessLayer.CoreServices;
using RoWalks;
using System.Web.Caching;
using BusinessLayer.CoreServices.Interfaces;
using NivelAccesDate_CF_ORM.Interfaces;
//using NivelAccesDate_CF_ORM.Interfaces;


namespace PresentationLayer_MVC.Infrastructure
{
    public class ContainerConfigurer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            builder.RegisterType<MemoryCacheService>()
                .As<ICache>();

            builder.RegisterType<DB_Context>()
                    .As<IRegionDBContext>()
                    .SingleInstance();

            builder.RegisterType<DB_Context>()
                    .As<ITrailDBContext>()
                    .SingleInstance();

            builder.RegisterType<RegionsAccessor>()
                    .As<IRegionsAccessor>();

            builder.RegisterType<TrailsAccessor>()
                    .As<ITrailsAccessor>();

            builder.RegisterType<RegionsService>()
                    .As<IRegions>();

            builder.RegisterType<TrailsService>()
                    .As<ITrails>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}