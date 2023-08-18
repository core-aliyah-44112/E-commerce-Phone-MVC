using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        WebBanXeEntities dbWeb = new WebBanXeEntities();
        // GET: Admin/Brand
        public ActionResult Category(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var lstCate = new List<Category>();
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
                lstCate = dbWeb.Categories.Where(x => x.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //Lấy all sản phẩm trong product
                lstCate = dbWeb.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            lstCate = lstCate.OrderByDescending(n => n.Id).ToList();
            return View(lstCate.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category objCate)
        {
            if (ModelState.IsValid) { 
                    if (objCate.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCate.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCate.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                        objCate.Avatar = fileName;
                        objCate.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category/"), fileName));
                        objCate.CreateOnUtc=DateTime.Now;
                        dbWeb.Categories.Add(objCate);
                        dbWeb.SaveChanges();
                        return RedirectToAction("Category");
                    }
                    else
                    {
                        return View();
                    }
            }
            return View();

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objCate = dbWeb.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCate);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objCate = dbWeb.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCate);
        }
        [HttpPost]
        public ActionResult Delete(Category objCate)
        {
            var objCategoty = dbWeb.Categories.Where((n) => n.Id == objCate.Id).FirstOrDefault();
            dbWeb.Categories.Remove(objCategoty);
            dbWeb.SaveChanges();
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objProduct = dbWeb.Categories.Where(n => n.Id == id).FirstOrDefault();
            Session["imgCate"]=objProduct.Avatar;
            return View(objProduct);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit( Category objCate)
        {
            if (objCate.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCate.ImageUpload.FileName);
                string extension = Path.GetExtension(objCate.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                objCate.Avatar = fileName;
                objCate.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category/"), fileName));
            }
            else
            {
                objCate.Avatar = Session["imgCate"].ToString();
            }
            objCate.UpdateOnUtc=DateTime.Now;
            dbWeb.Entry(objCate).State = EntityState.Modified;
            dbWeb.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}