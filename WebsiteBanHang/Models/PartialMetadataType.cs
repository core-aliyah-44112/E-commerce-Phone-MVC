using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Context
{
    [MetadataType(typeof(UsersMasterData))]
    public partial class User
    {
        public string ConfirmPasswords { get; set; }
        public bool Agree { get; set; }
        public bool Remember { get; set; }
    }
    [MetadataType(typeof(ProductMasterData))]
    public partial class Product { 
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(BrandMasterData))]
    public partial class Brand
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(CategoryMasterData))]
    public partial class Category
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(OrderMasterData))]
    public partial class Order
    {
    }

}