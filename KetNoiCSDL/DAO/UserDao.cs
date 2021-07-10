using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace KetNoiCSDL.DAO
{
    public class UserDao
    {
        BanHangOnlineDbContext db = null;
        public UserDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(String UserName, string PassWord)
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (res == null)
            {
                return 0;
            }
            else
            if (res.Status == false)
            {
                return -1;
            }
            else
            {
                if (res.Password == PassWord)
                    return 1;
                else
                    return -2;
            }
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) ||
                x.UserName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page,
            pageSize);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }


                user.Email = entity.Email;

                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
