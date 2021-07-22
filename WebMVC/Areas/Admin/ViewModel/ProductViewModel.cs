using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public string Name { set; get; }

        public long? CategoryID { set; get; }

        public long? ParentID { set; get; }


    }
}