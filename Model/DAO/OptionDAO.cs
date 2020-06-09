using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class OptionDAO
    {
        OnlineShopDbContext db = null;
        public OptionDAO()
        {
            db = new OnlineShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        public OPTION GetByID(int? id)
        {
            return db.OPTIONs.SingleOrDefault(x => x.OptionID == id);
        }
        public List<OPTION> ListAll()
        {
            return db.OPTIONs.ToList();
        }

        public int CreateOptions(OPTION opt)
        {
            //db.OPTIONs.Add(opt);
            //db.SaveChanges();
            //return opt.OptionID;
            var op = new OPTION() { OptionID = opt.OptionID, OptionName = opt.OptionName };
            db.OPTIONs.Add(op);
            db.SaveChanges();
            return op.OptionID;
        }
        public IEnumerable<OPTION> ListAllPaging(string searchOption, int page, int pageSize)
        {
            IQueryable<OPTION> option = db.OPTIONs;
            if (!string.IsNullOrEmpty(searchOption))
            {
                option = option.Where(x => x.OptionName.Contains(searchOption));
            }
            return option.ToPagedList(page, pageSize);
        }
        public bool DeleteOption(int ID)
        {
            try
            {
                var opt = GetByID(ID);
                db.OPTIONs.Remove(opt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(OPTION opt)
        {
            try
            {
                var option = GetByID(opt.OptionID);
                option.OptionName = opt.OptionName;
               
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
