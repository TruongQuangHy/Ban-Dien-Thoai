using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Dien_Thoai.Models
{
    
    public class PartialMetadataType
    {
    }
    [MetadataType(typeof(SanPhamMasterData))]
    public partial class SanPham
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}