using CNWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Model.DAO;
using Model.EF;

namespace CNWeb.Areas.Admin.Controllers
{
    public class OptionsController : Controller
    {
        private bool _;
        public ActionResult CreateOptions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOptions(OPTION model)
        {
            var res = new OptionDAO().CreateOptions(model);
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteOption(int id)
        {
            new OptionDAO().DeleteOption(id);
            return RedirectToAction("OptionList");
        }

        public ActionResult Edit(int id)
        {
            var opt = new OptionDAO().GetByID(id);
         
            ViewBag.OptionID = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(OptionModel model)
        {
            if (ModelState.IsValid)
            {
                var opt = new OptionDAO().GetByID(model.optionid);
                opt.OptionID = model.optionid;
                opt.OptionName = model.optionname;
               
                _ = new OptionDAO().Update(opt);
            }
            return RedirectToAction("OptionList");
        }

        public ActionResult OptionList()
        {
            var list = new OptionDAO().ListAll();
            return View(list);
        }
    }
}