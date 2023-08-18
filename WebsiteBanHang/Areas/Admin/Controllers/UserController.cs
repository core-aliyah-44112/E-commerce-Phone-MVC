using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebBanXeEntities dbWeb = new WebBanXeEntities();
        // GET: Admin/User
        public ActionResult User(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var lstUser = new List<User>();
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
                lstUser = dbWeb.Users.Where(x => x.FirstName.Contains(SearchString)||x.LastName.Contains(SearchString)).ToList();
            }
            else
            {
                //Lấy all sản phẩm trong product
                lstUser = dbWeb.Users.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objUser = dbWeb.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objUser = dbWeb.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Delete(User objUser)
        {
            var objUsers = dbWeb.Users.Where((n) => n.Id == objUser.Id).FirstOrDefault();
            dbWeb.Users.Remove(objUsers);
            dbWeb.SaveChanges();
            return RedirectToAction("User");
        }
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objUser = dbWeb.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                dbWeb.Configuration.ValidateOnSaveEnabled = false;
                dbWeb.Entry(user).State = EntityState.Modified;
                dbWeb.SaveChanges();
                return RedirectToAction("User");
            }catch(Exception ex)
            {
                return View();
            }
        }
    }
}