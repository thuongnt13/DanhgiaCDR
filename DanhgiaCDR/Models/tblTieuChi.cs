using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblTieuChi")]
    public partial class tblTieuChi
    {
        [Key]
        public int TieuChi_ID { get; set; }
        public int? LoaiPhieuDanhGia_ID { get; set; }
        public string? TieuChi_Ten { get; set; }
        public double? KhoangDiemmin { get; set; }
        public double? KhoangDiemmax { get; set; }
        public int? DongGopCDR { get; set; }
        public double? TrongSo { get; set; }
        public int? CDRMH_ID { get; set; }
        public int? TieuChi_Cap { get; set; }
        public int? TieuChi_Cha { get; set; }
        public bool? IsActve { get; set; }
        
        public int? ThuTu { get; set; }
    }
}
