using ProjectMgmtSvc.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ProjectMgmtSvc
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
