using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //AccountAdmin
            routes.MapRoute(
                name: "Order",
                url: "dat-hang/{id}",
                defaults: new { controller = "Order", action = "Order", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Thanh toán
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Payment", action = "Payment", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Giỏ hàng
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Cart", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Sản phẩm sales
            routes.MapRoute(
                name: "SalesProduct",
                url: "san-pham-sales",
                defaults: new { controller = "Product", action = "Product" },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Chi tiết sản phẩm
            routes.MapRoute(
                name: "ProductDetail",
                url: "san-pham-{slug}/{id}",
                defaults: new { controller = "Product", action = "Detail", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Thương hiệu
            routes.MapRoute(
                name: "BrandPro",
                url: "nhung-san-pham-thuong-hieu-{slug}/{id}",
                defaults: new { controller = "Brand", action = "BrandProduct", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            routes.MapRoute(
                name: "Brand",
                url: "thuong-hieu",
                defaults: new { controller = "Brand", action = "Brand" },
                new[] { "WebsiteBanHang.Controllers" }
            );

            //Danh mục
            routes.MapRoute(
                name: "CategoryPro",
                url: "nhung-san-pham-{slug}/{id}",
                defaults: new { controller = "Category", action = "ProductCategory", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            routes.MapRoute(
                name: "Category",
                url: "danh-muc",
                defaults: new { controller = "Category", action = "Category" },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Account
            routes.MapRoute(
                name: "Account",
                url: "thong-tin-{id}",
                defaults: new { controller = "Account", action = "Account", name = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Register
            routes.MapRoute(
                name: "Register",
                url: "dang-ki",
                defaults: new { controller = "Account", action = "Register" },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Login
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Login" },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //Logout
            routes.MapRoute(
               name: "Logout",
               url: "dang-xuat",
               defaults: new { controller = "Account", action = "Logout" },
               new[] { "WebsiteBanHang.Controllers" }
           );

            //Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Controllers" }
            );
            //
        }
    
    }
}
