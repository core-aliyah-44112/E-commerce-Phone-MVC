using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WebBanXeEntities dbWeb = new WebBanXeEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult AccountAdmin(int id)
        {
            var objaccount = dbWeb.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objaccount);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string passwords, bool remember)
        {
            if (ModelState.IsValid)
            {
                if (email.Length == 0)
                    ViewBag.error1 = "* Vui lòng nhập email.";
                if (passwords.Length == 0)
                    ViewBag.error2 = "* Vui lòng nhập password.";
                if (remember == true)
                {
                    var f_password = GetMD5(passwords);
                    var data = dbWeb.Users.Where(s => s.Email.Equals(email) && s.Passwords.Equals(f_password)&&s.IsAdmin==true).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["UserId"] = data.FirstOrDefault().Id;
                        Session["Gender"] = data.FirstOrDefault().Gender;
                        Session["Phone"] = data.FirstOrDefault().Phone;
                        Session["Address"] = data.FirstOrDefault().Address;
                        Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "* Đăng nhập thất bại!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.error3 = "* Bạn chưa đồng ý với thông tin đăng nhập.";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}