using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GVSU.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data.Entity;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(this.ConfigureJson);
            Database.SetInitializer<Models.ApplicationDbContext>(null);
        }

        private void ConfigureJson(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.Formatting
                = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new VolunteerConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new UserConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new ContactInfoConverter());

            JsonConvert.DefaultSettings = () =>
            {
                return config.Formatters.JsonFormatter.SerializerSettings;
            };
        }
    }
}
