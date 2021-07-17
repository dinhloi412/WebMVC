using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetNoiCSDL.DAO
{
    
    public class MenuDao
    {
        BanHangOnlineDbContext db = null;
        public MenuDao()
        {
            db = new BanHangOnlineDbContext();
        }
        public List<Menu>ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId &&x.Status==true     ).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
