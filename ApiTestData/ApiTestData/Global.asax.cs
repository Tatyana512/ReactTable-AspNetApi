using ApiTestData;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;

namespace apiTestData
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private  WindsorContainer _container;
        protected void Application_Start()
        {               
            GlobalConfiguration.Configure(WebApiConfig.Register);          
        }
    }
}
