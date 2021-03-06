﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GVSU.Data;
using GVSU.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Routing
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //JSON formatters
            GlobalConfiguration.Configure(this.ConfigureJson);

            //Bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ApplicationDbContext>(null);
        }

        private void ConfigureJson(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.Formatting
                = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new UserConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new VolunteerConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new CategoryConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new LocationConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new CharityConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new HourConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new BadgeConverter());

            JsonConvert.DefaultSettings = () =>
            {
                return config.Formatters.JsonFormatter.SerializerSettings;
            };
        }
    }
}
