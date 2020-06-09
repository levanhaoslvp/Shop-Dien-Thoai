using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using CNWeb.Areas.Admin.Models;

namespace CNWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private bool _;

        // GET: Admin/Product
        public ActionResult CreateProduct()
        {
            ViewBag.Option = new OptionDAO().ListAll();
            ViewBag.Cate = new CategoryDAO().ListAll();
            return View();
        }


        [HttpPost]
        public ActionResult CreateProduct(ProductModel model)
        {

            if (ModelState.IsValid)
            {
                var prod = new PRODUCT
                {
                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    ProductPrice = model.ProductPrice,
                    ProductDescription = model.ProductDescription,
                    PromotionPrice = model.PromotionPrice,
                    ProductStock = model.ProductStock,
                    CategoryID = model.CategoryID,
                    MetaKeyword = SlugGenerator.SlugGenerator.GenerateSlug(model.ProductName),
                    ShowImage = model.ShowImage,
                    ProductStatus = model.ProductStatus,
                    CreatedDate = DateTime.Now
                };
                int result = new ProductDAO().CreateProduct(prod);
                _ = new ImageDAO().CreateImg(model.ProductID, model.DetailImage_1, model.DetailImage_2, model.DetailImage_3);
                _ = new DetailDAO().AddProductDetail(model.ProductID, model.OptionID);
                return RedirectToAction("ProductList");
            }


            ViewBag.Option = new OptionDAO().ListAll();
            ViewBag.Cate = new CategoryDAO().ListAll();

            return View();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            new ProductDAO().DeleteProduct(id);
            return RedirectToAction("ProductList");
        }

        public ActionResult Edit(int id)
        {
            var prod = new ProductDAO().GetByID(id);
            ViewBag.Img1 = new ImageDAO().GetByID(id).DetailImage_1;
            ViewBag.Img2 = new ImageDAO().GetByID(id).DetailImage_2;
            ViewBag.Img3 = new ImageDAO().GetByID(id).DetailImage_3;
            ViewBag.Option = new OptionDAO().ListAll();
            ViewBag.Cate = new CategoryDAO().ListAll();
            return View(prod);
        }

        [HttpPost]

        public ActionResult Edit(ProductModel model)
        {

            if (ModelState.IsValid)
            {
                var prod = new ProductDAO().GetByID(model.ProductID);
                prod.ProductID = model.ProductID;
                prod.ProductName = model.ProductName;
                prod.ProductPrice = model.ProductPrice;
                prod.ProductDescription = model.ProductDescription;
                prod.PromotionPrice = model.PromotionPrice;
                prod.ProductStock = model.ProductStock;
                prod.CategoryID = model.CategoryID;
                prod.MetaKeyword = SlugGenerator.SlugGenerator.GenerateSlug(model.ProductName);
                prod.ShowImage = model.ShowImage;
                prod.ProductStatus = model.ProductStatus;
                prod.CreatedDate = DateTime.Now;
                _ = new ProductDAO().Update(prod);
                _ = new ImageDAO().UpdateImg(model.ProductID, model.DetailImage_1, model.DetailImage_2, model.DetailImage_3);
                _ = new DetailDAO().UpdateProductDetail(model.ProductID, model.OptionID);
                return RedirectToAction("ProductList");

            }
            ViewBag.Option = new OptionDAO().ListAll();
            ViewBag.Cate = new CategoryDAO().ListAll();

            return RedirectToAction("ProductList");
        }
        public ActionResult ProductList()
        {
            var list = new ProductDAO().ListAll();
            return View(list);
        }
    }
}