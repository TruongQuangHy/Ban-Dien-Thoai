using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Controllers
{
    public class ThanhToanController : Controller
    {
        DienThoaiEntities7 db = new DienThoaiEntities7();
        // GET: ThanhToan
        public ActionResult Index()
        {
            if (Session["maKH"] == null)
            {
                return RedirectToAction("Login", "NguoiDung");
            }
            else
            {
                //Lấy thông tin từ giỏ hàng qua biến Session
                var lstgiohang = (List<CartModel>)Session["cart"];
                // Lấy dữ liệu cho giỏ hàng
                DonHang dbdonhang = new DonHang();
                dbdonhang.tendonhang = "DonHang" + DateTime.Now.ToString("yyyyMMddHHmmss");
                dbdonhang.makh = int.Parse(Session["maKH"].ToString());
                dbdonhang.ngaydat = DateTime.Now;
                dbdonhang.tinhtrang = 1;
                db.SaveChanges();
                int intOrderId = dbdonhang.madon;
                List<ChiTietDonHang> listdonhangchitiet = new List<ChiTietDonHang>();
                foreach (var item in lstgiohang)
                {
                    ChiTietDonHang ctdh = new ChiTietDonHang();
                    ctdh.soluong = item.Quantity;
                    ctdh.madon = intOrderId;
                    ctdh.maSP = item.SanPham.maSP;
                    listdonhangchitiet.Add(ctdh);
                }
                db.ChiTietDonHangs.AddRange(listdonhangchitiet);
                db.SaveChanges();

            }
            return View();
        }

    }
}