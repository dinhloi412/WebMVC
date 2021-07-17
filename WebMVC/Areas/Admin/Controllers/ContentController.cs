using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetById(id);

            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var db = new BanHangOnlineDbContext();
                var dao = new ContentDao();

                    long id = dao.Insert(model);
                    if (id > 0)
                    {
                        SetAlert("Thêm  thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Thêm không thành công", "error");
                    }


            }
            SetViewBag(model.CategoryID);
            return View();
        }
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
               

            }
            SetViewBag(model.CategoryID);
            return View();
        }
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name",selectedID);
        }
    }
}