using KetNoiCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    [Serializable]
    public class CartItem
    {
       
        public  Product  Product{ set; get; }
        public long Quantity { set; get; }
         
    }
}