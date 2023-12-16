using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblCDRCTDT")]
    public partial class tblCDRCTDT

    {
        [Key]
        public int CDRCTDT_ID { get; set; }
        public string? CDRCTDT_Ten { get; set; }
        public int? CDRCTDT_Cap { get; set; }
        public string? CDRCTDT_KH { get; set; }
        public int? CDRCTDT_Cha { get; set; }
        public int? CTDT_ID { get; set; }
        public int? NangLuc_ID { get; set; }
        public string? TDNL_Ten { get; set; }
    }
}
