using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using WebsiteBanHang.Context;
using System.Windows;
using WebsiteBanHang.Models;
using static WebsiteBanHang.Common;
using System.Data;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebBanXeEntities dbWeb = new WebBanXeEntities();

        // GET: Admin/Product
        public ActionResult Product(string currentFilter, string SearchString, int? page)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var lstProduct = new List<Product>();
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
                lstProduct = dbWeb.Products.Where(x => x.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //Lấy all sản phẩm trong product
                lstProduct = dbWeb.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số item trong 1 trang = 5
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //Sắp xếp theo id sản phẩm , sản phẩm mới đưa lên đầu.
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    objProduct.CreateOnUtc = DateTime.Now;
                    dbWeb.Products.Add(objProduct);
                    dbWeb.SaveChanges();
                    return RedirectToAction("Product");
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
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objProduct = dbWeb.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objProduct = dbWeb.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = dbWeb.Products.Where((n) => n.Id == objPro.Id).FirstOrDefault();
            dbWeb.Products.Remove(objProduct);
            dbWeb.SaveChanges();
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }
            var objProduct = dbWeb.Products.Where(n => n.Id == id).FirstOrDefault();
            this.LoadData();
            Session["imgproduct"] = objProduct.Avatar.ToString();
            return View(objProduct);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            this.LoadData();
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
            }
            else
            {
                objProduct.Avatar = Session["imgproduct"].ToString();
            }
            objProduct.UpdateOnUtc = DateTime.Now;
            dbWeb.Entry(objProduct).State = EntityState.Modified;
            dbWeb.SaveChanges();
            return RedirectToAction("Product");
        }
        void LoadData()
        {
            Common common = new Common();
            //Lay du lieu danh mục dưới DB
            var lstCat = dbWeb.Categories.ToList();
            //Conver sang select list dang value ,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = common.ToSelectList(dtCategory, "Id", "Name");
            // Lay du lieu thuong hieu duoi DB

            var lstBrand = dbWeb.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = common.ToSelectList(dtBrand, "Id", "Name");
            // 
            List<ProductType> lstProductType = new List<ProductType>();

            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = common.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}