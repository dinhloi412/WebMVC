using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Category",
              url: "san-pham/{metatitle}-{id}",
              defaults: new { controller = "ProductCategory", action = "DanhMucSP", id = UrlParameter.Optional }
             , namespaces: new[] { "WebMVC.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               , namespaces: new[] { "WebMVC.Controllers" }
            );

            
        }
    }
}
