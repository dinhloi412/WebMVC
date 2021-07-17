using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace KetNoiCSDL.DAO
{
    public class ProductDao
    {
        BanHangOnlineDbContext db = null;
        public ProductDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) ||
                x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,
            pageSize);
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}
