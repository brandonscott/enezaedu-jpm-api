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
                name: "Authentication",
                routeTemplate: "authenticate",
                defaults: new { controller = "Users", action = "Authenticate" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // GENERIC ROUTES
            routes.MapHttpRoute(
                name: "UserClasses",
                routeTemplate: "users/{id}/classes",
                defaults: new { controller = "Users", action = "Classes" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapHttpRoute(
                name: "ClassStudents",
                routeTemplate: "classes/{id}/students",
                defaults: new { controller = "Classes", action = "Students" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapHttpRoute(
                name: "ControllerRoutes",
                routeTemplate: "{controller}"
            );

            routes.MapHttpRoute(
                name: "ControllerParams",
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
