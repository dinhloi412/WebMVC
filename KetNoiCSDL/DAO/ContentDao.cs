using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiCSDL.DAO
{
    public class ContentDao
    {

        BanHangOnlineDbContext db = null;
        public ContentDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public  Content GetById(long id)
        {
            return db.Contents.Find(id);
        }
        public long Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
    }
}
