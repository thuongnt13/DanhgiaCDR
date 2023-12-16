using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblMH")]
    public partial class tblMH
    {
        [Key]
        public int MH_ID { get; set; }
        public string? MH_Ten { get; set; }
        public int? MH_SoTinChi { get; set; }
        public int NGANH_ID { get; set; }
        public bool? IsActive { get; set; }
        public int CTDT_ID { get; internal set; }
        [ForeignKey("CTDT_ID")]
        public virtual tblCTDT CTDT { get; set; }
        //public virtual tblNganh tblNganh { get; set; }
        //public virtual tblCTDT tblCTDT { get; set; } 
    }
}
