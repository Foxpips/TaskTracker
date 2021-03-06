﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskTracker.IoC.BootStrappers;
using TaskTracker.IoC.Resolvers;

namespace TaskTracker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetCustomDependencyResolver();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        private static void SetCustomDependencyResolver()
        {
            var exportedTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            var unityContainer = new UnityBootstrapper().CreateContainer(exportedTypes);
            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }
    }
}