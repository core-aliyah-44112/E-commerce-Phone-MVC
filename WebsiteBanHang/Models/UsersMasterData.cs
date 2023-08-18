using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Context
{
    public partial class UsersMasterData
    {

        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Vui lòng nhập họ")]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* Vui lòng nhập tên")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="* Vui lòng nhập địa chỉ Email.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name ="Mật khẩu")]
        public string Passwords { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "* Vui lòng xác nhận mật khẩu")]
        [Compare("Passwords", ErrorMessage = "* Xác nhận mật khẩu không đúng, Nhập lại !")]
        [DataType(DataType.Password)]
        public string ConfirmPasswords { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "* Vui lòng nhập số điện thoại!")]
        [RegularExpression(@"^\(?([0-9]){10}", ErrorMessage ="* Số điện thoại không chính xác.")]
        public string Phone { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage ="* Vui lòng chọn giới tính")]
        public string Gender { get; set; }
        [Display(Name ="Địa chỉ")]
        [Required(ErrorMessage ="* Vui lòng nhập địa.")]
        public string Address { get; set; }
        [Display(Name ="Điều khoản")]
        public bool Agree { get; set; }
        public bool Remember { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}