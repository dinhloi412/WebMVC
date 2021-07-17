using KetNoiCSDL.DAO;
using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;

namespace WebMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.ChuoiTimKiem = searchString;
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var db = new BanHangOnlineDbContext();
                var dao = new UserDao();
                var MhMd5 = MaHoaMd5.MD5Hash(user.Password);
                user.Password = MhMd5;
                if (db.Users.Any(x => x.UserName == user.UserName))
                {
                    SetAlert("Tên đăng nhập này đã tồn tại", "error");
                }
                else
                {
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        SetAlert("Thêm User thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Thêm User không thành công", "error");
                    }
                }

            }
            return View("Create");

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var MhMd5 = MaHoaMd5.MD5Hash(user.Password);
                    user.Password = MhMd5;
                }
                var res = dao.Update(user);
                if (res)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("ThongBaoLoi", "Cập nhật không thành công.");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var user = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult changeStatus(long id)
        {
            var result = new UserDao().changeStatus(id);
            return Json(new
            {

                status = result

            });
        }
    }

}