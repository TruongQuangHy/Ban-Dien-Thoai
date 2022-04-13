using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Website_Dien_Thoai.Models;
using static Website_Dien_Thoai.Common;

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
        [HttpGet]
        public ActionResult Create()
        {
            Common common = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            // Lấy dữ liệu danh mục db
            var listThuongHieu = data.ThuongHieux.ToList();
            DataTable thuonghieu = converter.ToDataTable(listThuongHieu);
            ViewBag.listThuongHieu = common.ToSelectList(thuonghieu, "maTH", "tenTH");

            //Loại sản phẩm
            /*ProductType lstProduct = new ProductType();
            ProductType dbProduct = new ProductType();
            dbProduct.Id = 01;*/
            return View();
        }
        
        /*[ValidateInput(false)]*/
        [HttpPost]
        
        public ActionResult Create(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(sanpham.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(sanpham.ImageUpload.FileName);
                        string extension = Path.GetExtension(sanpham.ImageUpload.FileName);
                        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                        sanpham.hinh = fileName;
                        sanpham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                    }
                    data.SanPhams.Add(sanpham);
                    data.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(sanpham);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var detail_sanpham = data.SanPhams.Where(m => m.maSP == id).FirstOrDefault();
            return View(detail_sanpham);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var delete_sanpham = data.SanPhams.Where(m => m.maSP == id).FirstOrDefault();
            return View(delete_sanpham);
        }
        [HttpPost]
        public ActionResult Delete(SanPham sanPham)
        {
            var delete_sanpham = data.SanPhams.Where(m => m.maSP == sanPham.maSP).FirstOrDefault();
            data.SanPhams.Remove(delete_sanpham);   
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Edit_sanpham = data.SanPhams.Where(m => m.maSP == id).FirstOrDefault();
            return View(Edit_sanpham);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            if (sanPham.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(sanPham.ImageUpload.FileName);
                string extension = Path.GetExtension(sanPham.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                sanPham.hinh = fileName;
                sanPham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
            }
            data.Entry(sanPham).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}