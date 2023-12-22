using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblSV")]
    
    public partial class tblSV
    {
        [Key]
        public int SV_ID { get; set; }

        [Key]
        public int MH_ID { get; set; }

        public string SV_Ten { get; set; }
        public int? NGANH_ID { get; set; }
        public int? CTDT_ID { get; set; }
        public int? LHP_ID { get; set; }
        [Key]
        public int? MH_ID { get; set; }

        public virtual tblMH tblMH { get; set; }
        //public virtual ICollection<tblLoaiPhieu> tblLoaiPhieus { get; set; }
    }
}
