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
        /*[ValidateInput(false)]*/
        [HttpPost]
        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var D_theloai = data.ThuongHieux.Where(m => m.maTH == id).First();
            return View(D_theloai);
        }
        //-------------Create-------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, ThuongHieu thuonghieu)
        {
            var ten = collection["tenTH"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                thuonghieu.tenTH = ten;
                data.ThuongHieux.Add(thuonghieu);
                data.SaveChanges();
                return RedirectToAction("lstthuonghieu");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.ThuongHieux.First(m => m.maTH == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.ThuongHieux.First(m => m.maTH == id);
            var E_tenloai = collection["tenloai"];
            theloai.maTH = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenTH = E_tenloai;
                UpdateModel(theloai);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = data.ThuongHieux.First(m => m.maTH == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.ThuongHieux.Where(m => m.maTH == id).First();
            data.ThuongHieux.Remove(D_theloai);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}