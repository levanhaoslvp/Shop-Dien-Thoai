using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.DAO;
namespace Model.DAO
{
    public class DetailDAO
    {
        OnlineShopDbContext db = null;
        public DetailDAO()
        {
            db = new OnlineShopDbContext();
        }
        public List<PRODUCTDETAIL> ListAll()
        {
            return db.PRODUCTDETAILs.ToList();
        }
       
        public PRODUCTDETAIL GetByID(int id)
        {
            return db.PRODUCTDETAILs.Find(id);
        }

        public bool DeleteProductDetail(int OpID)
        {
            try
            {
                var Op = db.PRODUCTDETAILs.SingleOrDefault(x => x.ProductID == OpID);
                db.PRODUCTDETAILs.Remove(Op);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddProductDetail(int prodID, List<string> optionID)
        {
            try
            {
                
                foreach(var item in optionID)
                {
                    db.PRODUCTDETAILs.Add(new PRODUCTDETAIL { ProductID = prodID, OptionID = Int32.Parse(item) });   
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProductDetail(int prodID, List<string> optionID)
        {
            try
            {
                _ = DeleteProductDetail(prodID);
                _ = AddProductDetail(prodID, optionID);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
