using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Controllers
{
    public class ProducttController : Controller
    {
        DienThoaiEntities db = new DienThoaiEntities();
        public ActionResult ListProduct()
        {
            //lấy danh sách sản phẩm
            List<SanPham> lst_sanpham = db.SanPhams.ToList();
            return View(lst_sanpham);
        }
        // GET: Productt
        public ActionResult Detail(int id)
        {
            var detail = db.SanPhams.Where(n => n.maSP == id).FirstOrDefault();
            return View(detail);
        }
       
    }
}