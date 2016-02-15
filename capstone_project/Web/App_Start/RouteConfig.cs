using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Add custom about route
            routes.MapRoute(
                "AboutRoute",
                "About",
            new { controller = "Home", action = "About" });

            // Add custom contact route
            routes.MapRoute(
                "ContactRoute",
                "Contact",
            new { controller = "Home", action = "Contact" });

            // Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            // Show a 404 error page for anything else.
            // TODO: implement 404 page
            routes.MapRoute(
                "Error",
                "{*url}",
                new { controller = "Error", action = "404" });
        }
    }
}