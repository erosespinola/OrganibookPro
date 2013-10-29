﻿using Organibook.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Organibook
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}