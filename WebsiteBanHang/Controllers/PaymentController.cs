using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebBanXeEntities dbWeb =new WebBanXeEntities();
        // GET: Payment
        public ActionResult Payment()
        {
            if (Session["cart"]==null)
            {
                return RedirectToAction("Cart", "Cart");
            }
            
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                //Lấy infor từ giỏ hàng từ biến Sesstion
                var lstCart = (List<CartModel>)Session["cart"];
                //Gán dữ liệu cho order
                Order objOrder=new Order();
                objOrder.Name = "Đơn hàng " + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId=int.Parse(Session["UserId"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                dbWeb.Orders.Add(objOrder);
                //Lưu infor dữu liệu vào bảng Order 
                dbWeb.SaveChanges();
                //Lấy OrderId vừa mới tạo để lưu vào bảng orderdetail.
                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity=item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId=item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                dbWeb.OrderDetails.AddRange(lstOrderDetail);
                dbWeb.SaveChanges();
            }
            return View();
        }
    }
}