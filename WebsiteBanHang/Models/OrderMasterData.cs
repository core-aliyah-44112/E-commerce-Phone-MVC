using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Context
{
    public partial class OrderMasterData
    {
        public int Id { get; set; }
        [Display(Name ="Tên đơn hàng")]
        public string Name { get; set; }
        [Display(Name="ID Người dùng")]
        public Nullable<int> UserId { get; set; }
        [Display(Name ="Trạng thái")]
        public Nullable<int> Status { get; set; }
        [Display(Name="Ngày đặt hàng")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    }
}