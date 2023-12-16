using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblLoaiPhieu")]
    public partial class tblLoaiPhieu
    {
        [Key]
        public int LoaiPhieuDanhGia_ID { get; set; }
        public string? PhieuDanhGia_Ten { get; set; }
        public string? GhiChu { get; set; }
        public bool? IsActive { get; set; }
        public int MH_ID { get; set; }

    }
}
