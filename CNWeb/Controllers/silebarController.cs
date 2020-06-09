using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.MOD;
namespace CNWeb.Controllers
{
    public class silebarController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: silebar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeftBar()
        {
            var prod = db.PRODUCTs.ToList();
            var bar = db.CATEGORies.ToList();
            ViewBag.Bar = bar;
            ViewBag.Product = prod;
            return PartialView("_LeftBar");
        }

    }
}