using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.TuiFeaturePro = new ProductDao().FeatureProList(4);
            ViewBag.TuiNewPro = new ProductDao().NewProList(4);
            ViewBag.TuiSlide = new SlideDao().ListAll();
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]
       public ActionResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll1();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = new CategoryDao().ListAll1();
            return PartialView(model);
        }
    }
}