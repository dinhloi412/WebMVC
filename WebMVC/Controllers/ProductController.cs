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
        
        public ActionResult Detail(long cateId)
        {
            var product = new ProductDao().ViewDetail(cateId);
            ViewBag.Category = new ProductCategoryDao().ViewDDDD(product.CategoryID.Value);
            ViewBag.ListRelatedProduct = new ProductDao().ListRelatedProduct(cateId);
            return View(product);
        }
        public ActionResult ListProduct(int page = 1, int pageSize = 9)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPage(page, pageSize);
            return View(model); 
        }

    }
}