using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanhgiaCDR.Models
{
    [Table("tblLHP")]
    public partial class tblLHP
    {
        [Key]
        public int LHP_ID { get; set; }
        public int? GV_ID { get; set; }
        public string? MH_ID { get; set; }
        public string? LHP_Ten { get; set; }
        public bool? IsActive { get; set; }
    }
}
