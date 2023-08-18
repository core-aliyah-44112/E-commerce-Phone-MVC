using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;
using System.Web.Mvc;
using PagedList;

namespace WebsiteBanHang.Controllers
{
    public class BrandController : Controller
    {
        WebBanXeEntities dbWeb =new WebBanXeEntities();
        // GET: Brand
        [AllowAnonymous]
        public ActionResult Brand()
        {
            var lstBrand = dbWeb.Brands.Where(n=>n.ShowOnHomePage==true).ToList();
            return View(lstBrand);
        }
        [AllowAnonymous]
        public ActionResult BrandProduct(int id, string currentFilter, int? page)
        {  
            ViewBag.CurrentFilter = currentFilter;
            //Số item trong 1 trang = 5
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            var lstProduct = dbWeb.Products.Where(n => n.BrandId == id).ToList();
            Session["countPageBra"] = lstProduct.Count;
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}