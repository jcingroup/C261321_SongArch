using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotWeb.AppStart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Manager",
            url: "_SysAdm",
            defaults: new { controller = "_SysAdm", action = "Index" }
            ).DataTokens["UseNamespaceFallback"] = false;

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}/{ids}",
            defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional, ids = UrlParameter.Optional },
            namespaces: new string[] { "DotWeb.WebApp.Controllers" }
            
            ).DataTokens["UseNamespaceFallback"] = false;
        }
    }
}
