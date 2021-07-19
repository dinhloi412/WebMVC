using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        
        // GET: Admin/ProductCategory
        public ActionResult Index(String searchString,int page = 1, int pageSize = 15)
        {
          
            var dao = new ProductCategoryDao();


            var model = dao.ListAllPaging(searchString, page, pageSize);
            //SetViewBag(); dang bi loi view bag
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.ParentID = new SelectList(dao.ListAll(), "DisplayOrder", "Name",selectedID);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                long id = dao.Insert(productCategory);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "ProductCategory");
                }
                else
                {
                    SetAlert("Thêm  không thành công", "error");
                }
            }
            SetViewBag();
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = new ProductCategoryDao().Delete(id);
            SetViewBag();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult changeStatus1(long id)
        {
            var result = new ProductCategoryDao().changeStatus1(id);
            return Json(new
            {
              status = result

            });
        }

    }
}