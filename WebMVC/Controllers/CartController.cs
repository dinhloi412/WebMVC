using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Web.Script.Serialization;
using KetNoiCSDL.EF;
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
        public JsonResult Update(string cartModel)
        {
            var Jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[cartSession];
             
            foreach(var item  in sessionCart)
            {
                var jsonItem = Jsoncart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem!=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[cartSession] = sessionCart;
            return Json(new
            {
                status = true
            }); 
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
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipname, string mobile, string address, string email)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipName = shipname;
            order.ShipEmail = email;

            try
            {

                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[cartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quanlity = item.Quantity;
                    detailDao.Insert(orderDetail);
                }

            } catch(Exception ex)
            {
                return Redirect("/khong-hoan-thanh");
            }

            
            return Redirect("/hoan-thanh");

        }
        public ActionResult Success()
        {
            return View();
        }
    }
}