using System.ComponentModel.DataAnnotations;

namespace DanhgiaCDR.Models
{
    public class ViewHP
    {
        [Key]
        public int MH_ID { get; set; }
        public string? MH_Ten { get; set; }
        public int? MH_SoTinChi { get; set; }
        public int NGANH_ID { get; set; }
        public int CTDT_ID { get; internal set; }
    }
}
