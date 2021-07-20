using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private  const string cartSession = "cartSession";
        public ActionResult Index()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult  AddItem(long productID, int quantity)
        {
            var product = new ProductDao().ViewDetail(productID);
            var cart = Session[cartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x=>x.Product.ID== productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;

                        }
                    }
                }
                else
                {
                    // tạo mới đối tượng carditem
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                // gán vào session

                Session[cartSession] = list;

            }
            else
            {
                // tạo mới đối tượng carditem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                // gán vào session
                list.Add(item);
                Session[cartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}