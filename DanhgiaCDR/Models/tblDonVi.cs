using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblDonVi")]
    public partial class tblDonVi
    {
        [Key]
        public int DV_ID { get; set; }
        public string? DV_Ma { get; set; }
        public string? DV_Ten { get; set; }
        public string? DV_TenE { get; set; }
        public int? DV_Cap { get; set; }
        public int? DV_SoSinhVien { get; set; }
        public int? DV_SoCanBo { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? DV_NgayCapNhat { get; set; }
        public string? DV_NguoiCapNhat { get; set; }
        public bool? IsActive { get; set; }
    }
}
