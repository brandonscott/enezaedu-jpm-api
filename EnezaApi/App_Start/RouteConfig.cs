using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnezaApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "Registration",
                routeTemplate: "registration",
                defaults: new { controller = "Users", action = "Registration" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // GENERIC ROUTES
            routes.MapHttpRoute(
                name: "ControllerIdAction",
                routeTemplate: "{controller}/{*parameters}"
            );

            // DEFAULT ROUTE
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
