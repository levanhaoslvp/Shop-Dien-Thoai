using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class ImageDAO
    {
        OnlineShopDbContext db = null;
        public ImageDAO()
        {
            db = new OnlineShopDbContext();
        }
        public PRODUCTIMAGE GetByID(int id)
        {
            return db.PRODUCTIMAGEs.Find(id);
        }

        public bool CreateImg(int prodID, string img1,string img2,string img3)
        {
            try
            {
                var img = new PRODUCTIMAGE()
                {
                    ImageID = prodID,
                    DetailImage_1 = img1,
                    DetailImage_2 = img2,
                    DetailImage_3 = img3,
                    ProductID = prodID
                };
                db.PRODUCTIMAGEs.Add(img);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteImg(int id)
        {
            try
            {
               var img = db.PRODUCTIMAGEs.Find(id);
                db.PRODUCTIMAGEs.Remove(img);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public bool UpdateImg(int prodID, string img1, string img2, string img3)
        {
            try
            {
                _ = DeleteImg(prodID);
                _ = CreateImg(prodID, img1, img2, img3);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
