using Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDAO
    {
        OnlineShopDbContext db = null;
        public OrderDAO()
        {
            db = new OnlineShopDbContext();

        }
        public async Task<List<ORDER>> LoadOrder()
        {
            return await db.ORDERs.ToListAsync();
        }
        public ORDER GetByID(int? ID)

        {
            return db.ORDERs.Find(ID);
        }
        public async Task<int> ChangeOrder(ORDER ord)
        {
            try
            {
                var orderID = GetByID(ord.OrderID);
                var statusID = GetByID(ord.OrderStatusID);
                return  ord.OrderID;
            }
            catch
            {
                return 0;
            }
        }
    }
}
