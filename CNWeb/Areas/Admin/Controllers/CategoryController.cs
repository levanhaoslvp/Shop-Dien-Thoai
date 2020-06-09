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
    public class CategoryController : Controller
    {
        private bool _;
        public ActionResult CreateCategory()
        {
            //ViewBag.Option = new OptionDAO().ListAll();  
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var cate = new CATEGORY
                {
                    CategoryID = model.categoryid,
                    CategoryName = model.categoryname,
                    MetaKeyword = model.metakeyword,
                    CreatedDate = DateTime.Now
                };
                int result = new CategoryDAO().CreateCategory(cate);
                return RedirectToAction("CategoryList");
            }
            //ViewBag.Option = new OptionDAO().ListAll();
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            new CategoryDAO().DeleteCategory(id);
            return RedirectToAction("CategoryList");
        }

        public ActionResult Edit(int id)
        {
            var cate = new CategoryDAO().GetByID(id);
            //ViewBag.Option = new OptionDAO().ListAll();
            ViewBag.CategoryID = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var cate = new CategoryDAO().GetByID(model.categoryid);
                cate.CategoryID = model.categoryid;
                cate.CategoryName = model.categoryname;
                cate.MetaKeyword = model.metakeyword;
                cate.CreatedDate = DateTime.Now;
                _ = new CategoryDAO().Update(cate);
            }
            //ViewBag.Option = new OptionDAO().ListAll();
            return RedirectToAction("CategoryList");
        }

        public ActionResult CategoryList()
        {
            var list = new CategoryDAO().ListAll();
            return View(list);
        }
    }
}