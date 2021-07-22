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
                model = model.Where(x => x.Name.Contains(searchString) ||x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
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
                product.Image = entity.Image;
                product.Detail = entity.Detail;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
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
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Product> NewProList(int numpro)
        {
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(numpro).ToList();
        }
        public List<Product> FeatureProList(int numpro)
        {
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.ViewCount).Take(numpro).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public List<Product> ListRelatedProduct(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.CategoryID == product.CategoryID).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<Product> ListByCategoryID(long categoryID)
        {
            return db.Products.Where(x => x.CategoryID == categoryID).ToList();
        }
        public List<Product> ListByCategoryID1(long categoryID)
        {
            return db.Products.Where(x => x.CategoryID == categoryID).ToList();
        }
    }
}
