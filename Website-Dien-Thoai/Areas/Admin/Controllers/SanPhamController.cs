using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        DienThoaiEntities7 data = new DienThoaiEntities7();
        public ActionResult Index(string SearchString, string currentFilter, int ? page)
        {
            /* var all_sanpham = data.SanPhams.ToList();*/
            /*var all_sanpham = data.SanPhams.Where(m => m.tenSP.Contains(SearchString)).ToList();*/
            var listproduct = new List<SanPham>();
            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                listproduct = data.SanPhams.Where(m => m.tenSP.Contains(SearchString)).ToList();
            }
            else
            {
                listproduct = data.SanPhams.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listproduct = listproduct.OrderByDescending(m => m.maSP).ToList();
            return View(listproduct.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}