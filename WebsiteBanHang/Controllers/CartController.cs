using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class CartController : Controller
    {
        WebBanXeEntities dbWeb = new WebBanXeEntities();
        // GET: Cart
        public ActionResult Cart()
        {
            return View((List<CartModel>)Session["cart"]);
        }
        public ActionResult AddToCart(int id,double price, int quantity)
        {
            if (quantity < 1)
            {
                return View();
            }
            if (Session["cart"] == null) {
                List<CartModel> cart = new List<CartModel>();
                double total=price * quantity;
                cart.Add(new CartModel { Id = id, Product = dbWeb.Products.Find(id), Price = price, Quantity = quantity }); ;
                Session["cart"] = cart;
                Session["total"] = total;
                Session["count"] = 1;
            }
            else {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //Kiểm tra sản phảm có tồn tại trong giỏ hàng hay chưa?
                int index = isExist(id);
                if (index != -1) {
                    //Nếu sản phẩm đã có trong cart thì công  thêm số lượng
                    cart[index].Quantity += quantity;
                    Session["total"]=Convert.ToInt32(Session["total"])+quantity*price;
                }
                else {
                    //Nếu sản phẩm không tồn tại thì thêm sản phẩm vào giỏ hàng.
                    cart.Add(new CartModel { Id = id, Product =dbWeb.Products.Find(id),Price=price, Quantity = quantity });
                    //Tính lại sô sp trong cart.
                    Session["count"]=Convert.ToInt32(Session["count"])+1;
                    Session["total"] = Convert.ToInt32(Session["total"])+ quantity*price;
                }
                Session["cart"] = cart;
                
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++) {
                if (cart[i].Product.Id.Equals(id)) {
                    return i;
                }
            }
            return -1;
        }
        public ActionResult Remove(int id,double price,int quantity)
        {
            List<CartModel> li= (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.Id == id);
            Session["cart"]=li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            Session["total"] = Convert.ToInt32(Session["total"]) - quantity * price;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        public ActionResult UpdateCart(int id,int quantity)
        {
            //Fint cart update
            List<CartModel> cart = Session["cart"] as List<CartModel>;
            CartModel cartUpdate = cart.FirstOrDefault(n => n.Id == id&&n.Quantity!=quantity);
            if (cartUpdate != null)
            {
                Session["total"] = Convert.ToInt32(Session["total"]) + (quantity-cartUpdate.Quantity) * cartUpdate.Price;
                cartUpdate.Quantity = quantity;
            }
            return RedirectToAction("Cart");
        }

    }
}