using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using EMS.Services.App_Start;
using EMS.Services.Core.Config;
using EMS.Core.Services.Cors;
using StructureMap;
using EMS.Infra.CrossCutting.Ioc.DependencyResolution;

namespace EMS.Services
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalCustomizeConfig.CustomizeConfig(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            //dependency resoulver
            IContainer container = IoC.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }
    }
}