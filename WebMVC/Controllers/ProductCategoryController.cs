using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult category1(long cateId)
        {
            var category = new CategoryDao().viewDetail1(cateId);
            ViewBag.Category = category;
            var model = new ProductCategoryDao().ViewDetails(cateId);
            return View(model);
        }

    }
}