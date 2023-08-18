using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Context
{
    public class CategoryMasterData
    {
        public int Id { get; set; }
        [Display(Name ="Tên danh mục")]
        [Required(ErrorMessage ="Vui lòng nhập tên thương hiệu")]
        public string Name { get; set; }
        [Display(Name="Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name="Mã Url")]
        [Required(ErrorMessage ="Vui longc nhập mã url")]
        public string Slug { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập nhập mô tả")]
        public string ShortDetail { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> deleted { get; set; }
        [Display(Name="Thời gian tạo")]
        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
    }
}