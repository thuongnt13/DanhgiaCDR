using System.ComponentModel.DataAnnotations;

namespace DanhgiaCDR.Models
{
    public class View_Danhsach
    {
        [Key]
        public int SV_ID { get; set; }
        public string? SV_Ten { get; set; }
        public int CTDT_ID { get; set; }
        public string? CTDT_Ten { get; set; }
        public int NGANH_ID { get; set; }
        public string? NGANH_Ten { get; set; }
        //public int LoaiPhieuDanhGia_ID { get; set; }
        //public string? PhieuDanhGia_Ten { get; set; }
        public int MH_ID { get; set; }
        public string? MH_Ten { get; set; }
      
    }
}

