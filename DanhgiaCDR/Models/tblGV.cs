using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblGV")]
    public partial class tblGV
    {
        [Key]
        public int GV_ID { get; set; }
        public string? GV_Ten { get; set; }
        public int? LHP_ID { get; set; }
    }
}
