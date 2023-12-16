using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblCDRMH")]
    public partial class tblCDRMH
    {
        [Key]
        public int CDRMH_ID { get; set; }
        public int? MH_ID { get; set; }
        public int? CDRCTDT_ID { get; set; }
        public int? NangLuc_Id { get; set; }
        public string? TDNL_Ten { get; set; }
    }
}
