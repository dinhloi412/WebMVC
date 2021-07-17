using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiCSDL.DAO
{
   public class ProductCategoryDao
    {

        BanHangOnlineDbContext db = null;
        public ProductCategoryDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).ToList();
        }
    }
}
