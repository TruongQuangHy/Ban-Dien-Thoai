using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Dien_Thoai.Models
{
    public class CartModel
    {
        public SanPham SanPham { get; set; }
        public int Quantity { get; set; }
    }
}