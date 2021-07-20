﻿using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Detail(long cateId)
        {
            var product = new ProductDao().ViewDetail(cateId);
            ViewBag.Category = new ProductCategoryDao().ViewDDDD(product.CategoryID.Value);
            ViewBag.ListRelatedProduct = new ProductDao().ListRelatedProduct(cateId);
            return View(product);
        }
        public ActionResult ListProduct(long cateId)
        {
            var category = new ProductCategoryDao().viewDetail1(cateId);
            ViewBag.Category = category;
            var model = new ProductDao().ListByCategoryID1(cateId);
            return View(model);
        }

    }
}