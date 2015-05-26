using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace toda.api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoC.BuildContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
