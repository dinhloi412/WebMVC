using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 15)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name",
            selectedID);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            product.Image = "/Anh/" + filename;
            filename = Path.Combine(Server.MapPath("/Anh/"), filename);
            product.ImageFile.SaveAs(filename);
            using (BanHangOnlineDbContext banHang= new BanHangOnlineDbContext() )
            {
                banHang.Products.Add(product);
                banHang.SaveChanges();

            }
            ModelState.Clear();
            return View();
        }
       
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
               
                var res = dao.Update(product);
                if (res)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("ThongBaoLoi", "Cập nhật không thành công.");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
    }
}