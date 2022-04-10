using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Controllers
{
    public class CategoryController : Controller
    {
        DienThoaiEntities db = new DienThoaiEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult showdanhmuc(int id)
        {
            var list_sanpham = db.SanPhams.Where(n => n.maTH == id).ToList();
            return View(list_sanpham);
        }
    }
}