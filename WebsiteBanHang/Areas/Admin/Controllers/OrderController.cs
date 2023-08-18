using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebBanXeEntities dbWeb =new WebBanXeEntities();
        // GET: Admin/Order
        public ActionResult Order(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var lstOrder = new List<Order>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //Lấy danh sách sản phẩm  theo từ khóa tìm kiếm
                lstOrder = dbWeb.Orders.Where(x => x.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //Lấy all sản phẩm trong product
                lstOrder = dbWeb.Orders.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objOrder = dbWeb.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objOrder = dbWeb.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Delete(Order objOrder)
        {
            var objOrderPro = dbWeb.Orders.Where((n) => n.Id == objOrder.Id).FirstOrDefault();
            dbWeb.Orders.Remove(objOrderPro);
            dbWeb.SaveChanges();
            return RedirectToAction("Order");
        }
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            this.loadData();
            var objOrder = dbWeb.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Order objOrder)
        {
            this.loadData();
            dbWeb.Entry(objOrder).State = EntityState.Modified;
            dbWeb.SaveChanges();
            return RedirectToAction("Order");
        }
        void loadData()
        {
            Common common = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            List<OrderStatus> lstOrder = new List<OrderStatus>();

            OrderStatus objOrder = new OrderStatus();
            objOrder.Id = 01;
            objOrder.Name = "Đã đặt hàng - Đang chờ xử lý";
            lstOrder.Add(objOrder);

            objOrder = new OrderStatus();
            objOrder.Id = 02;
            objOrder.Name = "Đã xử lý - Đang giao hàng";
            lstOrder.Add(objOrder);

            DataTable dtOrder = converter.ToDataTable(lstOrder);
            ViewBag.OrderStatus = common.ToSelectList(dtOrder, "Id", "Name");

        }
    }
}