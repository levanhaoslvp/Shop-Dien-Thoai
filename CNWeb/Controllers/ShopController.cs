using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Mvc;
using Model.EF;
using PagedList;
using PagedList.Mvc;

namespace CNWeb.Controllers
{
    public class ShopController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

      //[Route("Shop/filter/{id}/{sort}")]

        public ActionResult Viewdefault(int? sort, int ?page)
        {
            List<PRODUCT> model1= new List<PRODUCT>();
            if (sort == null)
            {
                model1 = db.PRODUCTs.ToList();
            }
            else if (sort == 1)
            {
                model1 = db.PRODUCTs.OrderBy(p => p.ProductPrice).ToList();    
            }
            else
            {
                model1 = db.PRODUCTs.OrderByDescending(p => p.ProductPrice).ToList();
            }
            Session["SumPage"]= model1.Count();
            return PartialView("Viewdefault",model1.ToPagedList(page ?? 1, 9));
        }
    }
}