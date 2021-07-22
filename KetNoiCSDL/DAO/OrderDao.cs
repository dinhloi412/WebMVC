using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetNoiCSDL.EF;
namespace KetNoiCSDL.DAO
{
    public class OrderDao
    {
        BanHangOnlineDbContext db = null;
        public OrderDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
