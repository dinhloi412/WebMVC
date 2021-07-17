using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiCSDL.DAO
{
  public  class FooterDao
    {
        BanHangOnlineDbContext db = null;
        public FooterDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
