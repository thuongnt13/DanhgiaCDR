using System.ComponentModel.DataAnnotations;
namespace DanhgiaCDR.Models
{
    public class View_Loaiphieu
    {
        public int LoaiPhieuDanhGia_ID { get; set; }
        public string? PhieuDanhGia_Ten { get; set; }
        public int LHP_ID { get; set; }
        public string? LHP_Ten { get; set; }
        public int GV_ID { get; set; }
        public int MH_ID { get; set; }
        public string? MH_Ten { get; set; }
        public int SV_ID { get; set; }
        public string? SV_Ten { get; set; }
        [Key]
        public int TieuChi_ID { get; set; }
        public string? TieuChi_Ten { get; set; }
        
        
        
    }
}
