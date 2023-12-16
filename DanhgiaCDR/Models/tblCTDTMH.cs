using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblCTDTMH")]
    public partial class tblCTDTMH
    {
        [Key]
        public int CTDTMH_ID { get; set; }
        public int? CTDT_ID { get; set; }
        public int? CDRMH_ID { get; set; }
        public int? LoaiPhieuDanhGia_ID { get; set; }
    }
}
