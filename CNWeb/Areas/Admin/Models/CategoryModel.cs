using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNWeb.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string metakeyword { get; set; }
        public DateTime createdate { get; set; }
    }
}