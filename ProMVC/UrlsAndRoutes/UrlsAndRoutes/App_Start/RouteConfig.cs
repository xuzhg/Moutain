using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /*
            Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add("myRoute", myRoute);
            */

            routes.MapRoute("myRoute", "{controller}/{action}", new { controller = "Home", action = "Index" } );

            routes.MapRoute("", "public/{controller}/{action}", new { controller = "Home", action = "Index" });
        }
    }
}
