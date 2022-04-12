using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;
using PagedList.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Website_Dien_Thoai.Controllers
{
    public class HomeController : Controller
    {
        DienThoaiEntities7 db = new DienThoaiEntities7();
        public ActionResult Index()
        {
            HomeModel home = new HomeModel();
            home.listthuonghieu = db.ThuongHieux.ToList();
            home.listsanpham = db.SanPhams.ToList();
            return View(home);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}