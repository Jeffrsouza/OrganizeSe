using System;
using System.IO;
using System.Reflection;
using System.Web.Http;

namespace Organizese
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // WebApiConfig.Register(GlobalConfiguration.Configuration); // configuracao e rotas webapi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);// rotas mvc
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
