using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblDanhGiaNangLuc")]
    public partial class tblDanhGiaNangLuc
    {
        [Key]
        public int DanhGia_ID { get; set; }
        public int? SV_ID { get; set; }
        public double? DiemHe10 { get; set; }
        public double? DiemNangLuc { get; set; }
        public double? HonMongDoi { get; set; }
        public string? GhiChu { get; set; }
        public int? TieuChi_ID { get; set; }
    }
}
