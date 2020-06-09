using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class CategoryDAO
    {
        OnlineShopDbContext db = null;
        public CategoryDAO()
        {
            db = new OnlineShopDbContext();
        }
        public CATEGORY GetByID(int? id)
        {
            return db.CATEGORies.SingleOrDefault(x => x.CategoryID == id);
        }
        public List<CATEGORY> ListAll()
        {
            return db.CATEGORies.ToList();
        }
       
        public int CreateCategory(CATEGORY cate)
        {
            db.CATEGORies.Add(cate);
            db.SaveChanges();
            return cate.CategoryID;
        }
        public IEnumerable<CATEGORY> ListAllPaging(string searchCategory, int page, int pageSize)
        {
            IQueryable<CATEGORY> category = db.CATEGORies;
            if (!string.IsNullOrEmpty(searchCategory))
            {
                category = category.Where(x => x.CategoryName.Contains(searchCategory));
            }
            return category.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool DeleteCategory(int ID)
        {
            try
            {
                var cate = GetByID(ID);
                db.CATEGORies.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(CATEGORY cate)
        {
            try
            {
                var category = GetByID(cate.CategoryID);
                category.CategoryName = cate.CategoryName;
                category.MetaKeyword = cate.MetaKeyword;
                category.CreatedDate = cate.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public object Login()
        {
            throw new NotImplementedException();
        }
    }
}
