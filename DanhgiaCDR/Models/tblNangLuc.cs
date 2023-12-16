using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblNangLuc")]
    public partial class tblNangLuc
    {
        [Key]
        public int NangLuc_ID { get; set; }
        public int? SV_ID { get; set; }
        public double? Diem { get; set; }
        public int? MH_ÍD { get; set; }
        public int? CDRCTDT_ID { get; set; }
        public string? GhiChu { get; set; }
    }
}
