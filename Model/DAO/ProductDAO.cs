using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity;
using System.Data.SqlClient;
using PagedList;

namespace Model.DAO
{
    public class ProductDAO
    {
        OnlineShopDbContext db = null;
        public ProductDAO()
        {
            db = new OnlineShopDbContext();
        }

      
        public PRODUCT GetByID(int? ID)

        {
            return db.PRODUCTs.Find(ID);
        }

        public List<PRODUCT> GetByCateID(int ID)
        {
            return db.PRODUCTs.Where(x => x.CategoryID == ID).ToList();
        }
        public List<PRODUCT> ListAll()
        {
            return db.PRODUCTs.ToList();
        }

        public IEnumerable<PRODUCT> ListAllPaging(string searchProduct, int page, int pageSize)
        {
            IQueryable<PRODUCT> product = db.PRODUCTs;
            if (!string.IsNullOrEmpty(searchProduct))
            {
                product = product.Where(x => x.ProductName.Contains(searchProduct));
            }
            return product.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public int CreateProduct(PRODUCT product)
        {
            db.PRODUCTs.Add(product);
            db.SaveChanges();
            return product.ProductID;
        }

        public bool DeleteProduct(int ID)
        {
            try
            {
                var prod = GetByID(ID);
                db.PRODUCTs.Remove(prod);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Update(PRODUCT prod)
        {
            try
            {
                var product = GetByID(prod.ProductID);
                product.ProductName = prod.ProductName;
                product.ProductPrice = prod.ProductPrice;
                product.ProductDescription = prod.ProductDescription;
                product.PromotionPrice = prod.PromotionPrice;
                product.ProductStock = prod.ProductStock;
                product.CategoryID = prod.CategoryID;
                product.MetaKeyword = prod.MetaKeyword;
                product.ShowImage = prod.ShowImage;
                product.ProductStatus = prod.ProductStatus;
                product.CreatedDate = prod.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public List<OptionModel> ShowOption(string Prodname)
        //{
        //    var model = from p in db.PRODUCTs.AsEnumerable()
        //                join d in db.PRODUCTDETAILs.AsEnumerable() on p.ProductID equals d.ProductID
        //                join o in db.OPTIONs.AsEnumerable() on d.OptionID equals o.OptionID
        //                where p.ProductName == Prodname
        //                select new OptionModel() { Option = o.OptionName, Price = p.ProductPrice };
        //    return model.ToList();
        //}
    }
}