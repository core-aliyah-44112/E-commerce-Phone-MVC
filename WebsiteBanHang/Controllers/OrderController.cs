using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class OrderController : Controller
    {
        WebBanXeEntities dbWeb =new WebBanXeEntities();
        // GET: Order
        public ActionResult Order(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index","Home");
            }
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.User=dbWeb.Users.Where(u=>u.Id==id).ToList();
            objHomeModel.ListOrderDetail=dbWeb.OrderDetails.ToList();
            objHomeModel.ListOrder = dbWeb.Orders.ToList();
            objHomeModel.ListProduct = dbWeb.Products.ToList();
            return View(objHomeModel);
        }
    }
}