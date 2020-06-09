using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace CNWeb.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Order()
        {
            return View();
        }

        public async Task<ActionResult> OrderList()
        {
            var list = new List<ORDERSTATU>();
            foreach (var item in await new OrderStatusDAO().LoadStatus())
            {
                if (item.StatusID != 5)
                {
                    list.Add(item);
                }
            }
            ViewBag.Status = list;
            return PartialView("OrderList", await new OrderDAO().LoadOrder());
        }
        [HttpPost]
        public async Task<JsonResult> EditOrder(ORDER model)
        {
            try
            {
                int result = await new OrderDAO().ChangeOrder(model);
                if (result == 0)
                {
                    return Json(new { Success = false, model }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Success = true, model }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Success = false, model }, JsonRequestBehavior.AllowGet);
            }
        }
        public async Task<JsonResult> StatusList(int id)
        {
            var db = await new OrderStatusDAO().LoadStatus();
            if (id == 2)
            {
                var list = new List<ORDERSTATU>();
                list.Add(db.Where(x => x.StatusID == 3).FirstOrDefault());
                list.Add(db.Where(x => x.StatusID == 4).FirstOrDefault());

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else if (id == 1)
            {
                var list = new List<ORDERSTATU>();
                foreach (var item in db)
                {
                    if (item.StatusID != 1)
                    {
                        list.Add(item);
                    }
                }
                return Json(db, JsonRequestBehavior.AllowGet);
            }
            return Json(new List<ORDERSTATU>(), JsonRequestBehavior.AllowGet);
        }

    }
}