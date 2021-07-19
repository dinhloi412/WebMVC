using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace WebMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            SetViewBag();
            return View(product);
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
            if(product.ImageFile!=null)
            {
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                product.Image = "/Anh/" + filename;
                filename = Path.Combine(Server.MapPath("/Anh/"), filename);
                product.ImageFile.SaveAs(filename);
                using (BanHangOnlineDbContext banHang = new BanHangOnlineDbContext())
                {
                    banHang.Products.Add(product);
                    banHang.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            
            SetViewBag();
            return View();
        }
       
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (product.ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                product.Image = "/Anh/" + filename;
                filename = Path.Combine(Server.MapPath("/Anh/"), filename);
                product.ImageFile.SaveAs(filename);
                using (BanHangOnlineDbContext banHang = new BanHangOnlineDbContext())
                {
                    banHang.Entry(product).State = EntityState.Modified;
                    banHang.SaveChanges();
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index");

                }
            }

            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            SetViewBag();
            return View(product);
        }
       
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var product = new ProductDao().Delete(id);
            SetAlert("Xoá thành công", "success");
            return RedirectToAction("Index");
        }
    }
}