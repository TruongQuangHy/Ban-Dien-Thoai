using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin/Admin
        /*public ActionResult Admin()
        {
            DienThoaiEntities2 db = new DienThoaiEntities2();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            var all_sanpham = from ss in db.SanPhams select ss;
            //return View(all_sanpham);
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("XacNhanAdmin", "GioHang");
            }
            else
            {
                if (kh.admin == 1)
                {

                    return View(all_sanpham);
                }
                else
                {
                    return RedirectToAction("DaXacNhanAdmin", "GioHang");
                }
            }
        }*/
    }
}