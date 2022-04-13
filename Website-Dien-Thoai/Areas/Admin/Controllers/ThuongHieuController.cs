using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;

namespace Website_Dien_Thoai.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        DienThoaiEntities7 data = new DienThoaiEntities7();
        // GET: Admin/ThuongHieu
        public ActionResult lstthuonghieu(string SearchString, string currentFilter, int? page)
        {
            /* var all_sanpham = data.SanPhams.ToList();*/
            /*var all_sanpham = data.SanPhams.Where(m => m.tenSP.Contains(SearchString)).ToList();*/
            var listproduct = new List<ThuongHieu>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                listproduct = data.ThuongHieux.Where(m => m.tenTH.Contains(SearchString)).ToList();
            }
            else
            {
                listproduct = data.ThuongHieux.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            listproduct = listproduct.OrderByDescending(m => m.maTH).ToList();
            return View(listproduct.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            var Create_thuonghiue = data.ThuongHieux.ToString();
            return View(Create_thuonghiue);
        }

        /*[ValidateInput(false)]*/
        [HttpPost]

        public ActionResult Create(ThuongHieu thuongHieu)
        {
            data.ThuongHieux.Add(thuongHieu);
            data.SaveChanges();
            return RedirectToAction("lstthuonghieu");
        }
    }
}