using KetNoiCSDL.DAO;
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

        public ActionResult DanhMucSP(long id)
        {
            ViewBag.DmSp = new ProductCategoryDao().DStheoID(id);
            return View();
        }
    }
}