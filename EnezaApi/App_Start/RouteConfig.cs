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
                routeTemplate: "api/authenticate",
                defaults: new { controller = "Users", action = "Authenticate" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapHttpRoute(
                name: "UserRegistration",
                routeTemplate: "api/users",
                defaults: new { controller = "Users", action = "Registration" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapHttpRoute(
               name: "UserClasses",
               routeTemplate: "api/users/{id}/classes",
               defaults: new { controller = "Users", action = "Classes" },
               constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
           );

            routes.MapHttpRoute(
                name: "ClassStudents",
                routeTemplate: "api/classes/{id}/students",
                defaults: new { controller = "Classes", action = "Students" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapHttpRoute(
                name: "AddToStudents",
                routeTemplate: "api/classes/{id}/add/{userId}",
                defaults: new { controller = "Classes", action = "AddUser" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapHttpRoute(
                name: "RemoveFromClass",
                routeTemplate: "api/classes/{id}/delete/{userId}",
                defaults: new { controller = "Classes", action = "DeleteUser" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "DELETE" }) }
            );

            routes.MapHttpRoute(
                name: "SchoolsAverageScores",
                routeTemplate: "api/schools/averagescores",
                defaults: new { controller = "Schools", action = "AverageScores" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapHttpRoute(
                name: "UserMessages",
                routeTemplate: "api/users/{id}/messages/{timestamp}",
                defaults: new { controller = "Users", action = "Messages" },
                constraints: new { HttpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // GENERIC ROUTES
            routes.MapHttpRoute(
                name: "ControllerRoutes",
                routeTemplate: "api/{controller}"
            );

            routes.MapHttpRoute(
                name: "ControllerParams",
                routeTemplate: "api/{controller}/{*parameters}"
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
