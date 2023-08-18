using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Context
{

    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        [Required]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        [Required(ErrorMessage ="Vui lòng nhập mô tả ngắn cho sản phẩm")]
        [StringLength(500,ErrorMessage ="Mô tả ngắn phải từ 50 - 500 kí tự.",MinimumLength =50)]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string FullDescription { get; set; }
        [Display(Name="Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public Nullable<double> Price { get; set; }
        [Display(Name="Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Phân loại")]
        [Required]
        public Nullable<int> TypeId { get; set; }
        [Display(Name="Mã URL")]
        [Required(ErrorMessage ="Vui lòng nhập mã URL")]
        public string Slug { get; set; }
        [Display(Name = "Thương hiệu")]
        [Required]
        public Nullable<int> BrandId { get; set; }
        [Display(Name ="Quyền xóa")]
        public Nullable<bool> Deleted { get; set; }
        [Display(Name="Hiển thị")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name="Thời gian tạo")]
        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        [Display(Name="Thời gian cập nhật")]
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }

    }
}
