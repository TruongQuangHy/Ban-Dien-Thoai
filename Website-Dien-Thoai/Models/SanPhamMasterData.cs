using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Dien_Thoai.Models
{
    public partial class SanPhamMasterData
    {

        public int maSP { get; set; }
        [Required(ErrorMessage = "Bạn hãy nhập đủ thông tin")]
        [Display(Name = "Thương hiệu")]
        public Nullable<int> maTH { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string tenSP { get; set; }
        [Display(Name = "Ảnh sản phâm")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Nullable<decimal> giaban { get; set; }
        [Display(Name = "Ngày cập nhập")]
        public Nullable<System.DateTime> ngaycapnhat { get; set; }
        [Display(Name = "Số lượng")]
        public Nullable<int> soluongton { get; set; }
        [Display(Name = "Mô tả")]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ThuongHieu ThuongHieu1 { get; set; }
/*
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }*/
    }
}