using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class ListProductController : Controller
    {
        // GET: ListProduct
        public ActionResult Index()
        {
            return View();
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