using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.DAO
{
    public class OrderDetailDAO
    {
        OnlineShopDbContext db = null;
        public OrderDetailDAO()
        {
            db = new OnlineShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<ORDERDETAIL> LoadOrderDetail(int OrderID)
        {
            return db.ORDERDETAILs.AsNoTracking().Where(x => x.OrderID == OrderID).ToList();
        }

    }
}
