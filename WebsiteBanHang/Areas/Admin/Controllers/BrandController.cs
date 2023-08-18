using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteBanHang.Context;
using System.Web;
using System.Web.Mvc;
using System.IO;
using static WebsiteBanHang.Common;
using System.Data.Entity;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        WebBanXeEntities dbWeb =new WebBanXeEntities();
        // GET: Admin/Brand
        public ActionResult Brand(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var lstBrand = new List<Brand>();
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
                lstBrand = dbWeb.Brands.Where(x => x.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //Lấy all sản phẩm trong product
                lstBrand = dbWeb.Brands.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(Brand objBrand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/brand/"), fileName));
                        objBrand.CreateOnUtc=DateTime.Now;
                        dbWeb.Brands.Add(objBrand);
                        dbWeb.SaveChanges();
                        return RedirectToAction("Brand");
                    }
                    else
                    {
                        return View();
                    }
                }
                catch (Exception)
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
            var objBrandProduct = dbWeb.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrandProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objBrandProduct = dbWeb.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrandProduct);
        }
        [HttpPost]
        public ActionResult Delete(Brand objBrand)
        {

            var objBrandProduct = dbWeb.Brands.Where((n) => n.Id == objBrand.Id).FirstOrDefault();
            dbWeb.Brands.Remove(objBrandProduct);
            dbWeb.SaveChanges();
            return RedirectToAction("Brand");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objProduct = dbWeb.Brands.Where(n => n.Id == id).FirstOrDefault();
            Session["imgbrand"] = objProduct.Avatar;
            return View(objProduct);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
            }
            else
            {
                objBrand.Avatar = Session["imgbrand"].ToString();
            }
            objBrand.UpdateOnUtc= DateTime.Now;
            dbWeb.Entry(objBrand).State = EntityState.Modified;
            dbWeb.SaveChanges();
            return RedirectToAction("Brand");
        }
    }
}