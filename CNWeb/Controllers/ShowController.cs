using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.Win32;
using Model.EF;

namespace CNWeb.Controllers
{
    public class ShowController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: Show
    
        public ActionResult Index(int? id)
        {
            var listProduct1 = db.PRODUCTs.Where(p => p.ProductID ==id).ToList();
            ViewBag.Product = listProduct1;
            var listPhone = db.PRODUCTIMAGEs.Where(q => q.ProductID == id).ToList();
            ViewBag.ProductImage = null;
            ViewBag.ProductImage = listPhone;

           
            return View("Show");
        }
    }
}