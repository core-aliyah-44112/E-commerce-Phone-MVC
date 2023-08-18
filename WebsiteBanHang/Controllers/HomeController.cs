using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebBanXeEntities dbWeb = new WebBanXeEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel=new HomeModel();
            objHomeModel.ListCategory = dbWeb.Categories.ToList();
            objHomeModel.ListProduct=dbWeb.Products.ToList();
            objHomeModel.ListBrand=dbWeb.Brands.ToList();


            return View(objHomeModel);
        }
        /*
        //GET: Register
        [HttpGet]
        [AllowAnonymous]
        [ActionName("dang-ky")]
        public ActionResult Register()
        {
            return View("Register");
        }

        //POST: Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                bool agree =Convert.ToBoolean(_user.Agree.ToString());
                if (agree == true)
                {
                    var check = dbWeb.Users.FirstOrDefault(s => s.Email == _user.Email);
                    if (check == null)
                    {
                        _user.Passwords = GetMD5(_user.Passwords);
                        dbWeb.Configuration.ValidateOnSaveEnabled = false;
                        dbWeb.Users.Add(_user);
                        dbWeb.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "* Email đã tồn tại. Vui lòng nhập địa chỉ email khác!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.error1 = "* Bạn chưa đồng ý với điểu khoản!";
                }
                
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [ActionName("dang-nhap")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string passwords,bool remember)
        {
            if (ModelState.IsValid) {
                if (email.Length == 0)
                    ViewBag.error1 = "* Vui lòng nhập email.";
                if (passwords.Length == 0)
                    ViewBag.error2 = "* Vui lòng nhập password.";
                if (remember == true)
                {
                    var f_password = GetMD5(passwords);
                    var data = dbWeb.Users.Where(s => s.Email.Equals(email) && s.Passwords.Equals(f_password)).ToList();
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
                        return RedirectToAction("Index");
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
            else {
                return View();
            }
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        //Account
        public ActionResult Account(int id)
        {
            var objaccount = dbWeb.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objaccount);
        }
        //create a string MD5
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
        } */
        
    }
}