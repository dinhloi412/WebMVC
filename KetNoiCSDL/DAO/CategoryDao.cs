using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiCSDL.DAO
{
    public class CategoryDao
    {
        BanHangOnlineDbContext db = null;
        public CategoryDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public List<Category> ListAll1()
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory viewDetail1(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }

}

