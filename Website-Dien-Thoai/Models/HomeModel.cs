using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace Website_Dien_Thoai.Models
{
    public class HomeModel
    {
        public List<SanPham> listsanpham { get; set; }
        public List<ThuongHieu> listthuonghieu { get; set; }
    }
}