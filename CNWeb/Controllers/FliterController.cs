using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CNWeb.Controllers
{
    public class FliterController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: Fliter
        public ActionResult Index(string id, int? sort)
        {
                Session["hangsx"] = id;
                Session["sort"] = sort;
                return View();
            
        }
        public ActionResult result(string id, int? sort, int? page)
        {
            List<PRODUCT> model1 = new List<PRODUCT>();

            if (id =="")
            {
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
            }
            else
            {
                Session["hangsx"] = id;
                var cate = db.CATEGORies.Where(p => p.CategoryName == id).FirstOrDefault();
                int idcate = cate.CategoryID;

                if (sort == null)
                {
                    model1 = db.PRODUCTs.Where(P => P.CategoryID == idcate).ToList();
                }
                else if (sort == 1)
                {
                    model1 = db.PRODUCTs.OrderBy(p => p.ProductPrice).Where(P => P.CategoryID == idcate).ToList();
                }
                else
                {
                    model1 = db.PRODUCTs.OrderByDescending(p => p.ProductPrice).Where(P => P.CategoryID == idcate).ToList();
                }
            }
            ViewBag.cout = model1.Count();
            return PartialView("/Views/Shop/filterPro.cshtml",model1.ToPagedList(page ?? 1,9));
        }
    }
}