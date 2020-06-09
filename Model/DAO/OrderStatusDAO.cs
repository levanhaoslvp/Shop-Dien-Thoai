using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
    public class OrderStatusDAO
    {
        OnlineShopDbContext db = null;
        public OrderStatusDAO()
        {
            db = new OnlineShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public async Task<List<ORDERSTATU>> LoadStatus()
        {
            return await db.ORDERSTATUS.ToListAsync();
        }
    }
}
