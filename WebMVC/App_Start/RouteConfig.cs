﻿using System;
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
                name: "Product Category",
                url: "san-pham/{metatitle}-{cateId}",
                defaults: new { controller = "ProductCategory", action = "category1", id = UrlParameter.Optional }
               , namespaces: new[] { "WebMVC.Controllers" }
            );



            routes.MapRoute(
                name: "Product lisst",
                url: "loai-san-pham/{metatitle}-{cateId}",
                defaults: new { controller = "Product", action = "ListProduct", id = UrlParameter.Optional }
               , namespaces: new[] { "WebMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{cateId}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
               , namespaces: new[] { "WebMVC.Controllers" }
            );


            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
               , namespaces: new[] { "WebMVC.Controllers" }
            );
           
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
              , namespaces: new[] { "WebMVC.Controllers" }
           );
            routes.MapRoute(
              name: "Payment",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }
             , namespaces: new[] { "WebMVC.Controllers" }
          );
            routes.MapRoute(
             name: "Payment Success",
             url: "hoan-thanh",
             defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }
            , namespaces: new[] { "WebMVC.Controllers" }
         );
            routes.MapRoute(
            name: "Contact",
            url: "lien-he",
            defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
           , namespaces: new[] { "WebMVC.Controllers" }
        );
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
           name: "dangky",
           url: "dang-ky",
           defaults: new { controller = "User", action = "Resgister", id = UrlParameter.Optional }
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
