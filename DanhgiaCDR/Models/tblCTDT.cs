using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblCTDT")]
    public partial class tblCTDT
    {
        [Key]
        public int CTDT_ID { get; set; }
        public string? CTDT_Ten { get; set; }
        public int? NGANH_ID { get; set; }
        public string? CTDT_So { get; set; }
        public int? DV_ID { get; set; }
        public int? CTDT_SoTinChi { get; set; }
        public DateTime? CTDT_NamBatDau { get; set; }
        public double? CTDT_ThoiGianToiDa { get; set; }
        public double? CTDT_ThoiGianToiThieu { get; set; }
        public string? CTDT_GhiChu { get; set; }
        public string? CTDT_File { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<tblMH> tblMHs { get; set; }
        //public virtual tblNganh tblNganhs { get; set; }
    }
}
