using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNWeb.Areas.Admin.Models
{
   // [Table("Product")]
    public class ProductModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage ="Nhập tên")]    
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Nhập giá")]
        public decimal ProductPrice { get; set; }

        public decimal PromotionPrice { get; set; }

        public string ShowImage { get; set; }

        public string DetailImage_1 { get; set; }
        public string DetailImage_2 { get; set; }
        public string DetailImage_3 { get; set; }

        public bool? ProductStatus { get; set; }

        public int ProductStock { get; set; }
       
        public int CategoryID { get; set; }

        public List<string> OptionID { get; set; }
    }
}