using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblNGANH")]
    public partial class tblNganh
    {
        [Key]
        public int NGANH_ID { get; set; }
        public int? DV_ID { get; set; }
        public string? NGANH_Ten { get; set; }
        public string? NGANH_TenE { get; set; }
        public int? NGANH_Cap { get; set; }
        public int? NGANH_ID_Cha { get; set; }
        public double? NGANH_ThoiGianToiThieu { get; set; }
        public double? NGANH_ThoiGianToiDa { get; set; }
        public bool? IsActive { get; set; }
    }
}
