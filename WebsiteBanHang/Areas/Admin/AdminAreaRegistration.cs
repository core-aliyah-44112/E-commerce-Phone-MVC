using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //AdminAcount
            context.MapRoute(
               name: "AdminLogin",
               url: "login-admin",
               defaults: new { controller = "Home", action = "Login", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminLogout",
               url: "logout-admin",
               defaults: new { controller = "Home", action = "Logout", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminAccount",
               url: "account-admin/{id}",
               defaults: new { controller = "Home", action = "AccountAdmin", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //AdminUser
            context.MapRoute(
               name: "AdminUserDelete",
               url: "tai-khoan-delete/{id}",
               defaults: new { controller = "User", action = "Delete", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminUserEdit",
               url: "tai-khoan-edit/{id}",
               defaults: new { controller = "User", action = "Edit", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminUserDetail",
               url: "tai-khoan-details/{id}",
               defaults: new { controller = "User", action = "Details", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminUser",
               url: "quan-ly-user",
               defaults: new { controller = "User", action = "User", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //AdminOrder
            
            context.MapRoute(
               name: "AdminOrderDelete",
               url: "don-hang-delete/{id}",
               defaults: new { controller = "Order", action = "Delete", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminOrderDetail",
               url: "don-hang-details/{id}",
               defaults: new { controller = "Order", action = "Details", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminOrderEdit",
               url: "don-hang-edit/{id}",
               defaults: new { controller = "Order", action = "Edit", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminOrder",
               url: "quan-ly-order",
               defaults: new { controller = "Order", action = "Order", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //AdminCate
            context.MapRoute(
              name: "AdminCateCreate",
              url: "them-danh-muc",
              defaults: new { controller = "Category", action = "Create", slug = UrlParameter.Optional, id = UrlParameter.Optional },
               new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               name: "AdminCateDelete",
               url: "danh-muc-{slug}-delete/{id}",
               defaults: new { controller = "Category", action = "Delete", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminCateDetail",
               url: "danh-muc-{slug}-details/{id}",
               defaults: new { controller = "Category", action = "Details", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminCateEdit",
               url: "danh-muc-{slug}-edit/{id}",
               defaults: new { controller = "Category", action = "Edit", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminCate",
               url: "quan-ly-danh-muc",
               defaults: new { controller = "Category", action = "Category", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //AdminBrand
            context.MapRoute(
               name: "AdminBrandCreate",
               url: "them-thuong-hieu",
               defaults: new { controller = "Brand", action = "Create", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminBrandDelete",
               url: "thuong-hieu-{slug}-delete/{id}",
               defaults: new { controller = "Brand", action = "Delete", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminBrandDetail",
               url: "thuong-hieu-{slug}-details/{id}",
               defaults: new { controller = "Brand", action = "Details", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminBrandEdit",
               url: "thuong-hieu-{slug}-edit/{id}",
               defaults: new { controller = "Brand", action = "Edit", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminBrand",
               url: "quan-ly-thuong-hieu",
               defaults: new { controller = "Brand", action = "Brand", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //AdminProduct
            context.MapRoute(
               name: "AdminProductCreate",
               url: "them-san-pham",
               defaults: new { controller = "Product", action = "Create", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminProductDelete",
               url: "san-pham-{slug}-delete/{id}",
               defaults: new { controller = "Product", action = "Delete", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminProductDetail",
               url: "san-pham-{slug}-detail/{id}",
               defaults: new { controller = "Product", action = "Details", slug = UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminProductEdit",
               url: "san-pham-{slug}-edit/{id}",
               defaults: new { controller = "Product", action = "Edit",slug=UrlParameter.Optional, id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            context.MapRoute(
               name: "AdminProduct",
               url: "quan-ly-san-pham",
               defaults: new { controller = "Product", action = "Product", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
            //Admin
            context.MapRoute(
               name: "Admin_default",
               url: "admin",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "WebsiteBanHang.Areas.Admin.Controllers" }
            );
        }
    }
}