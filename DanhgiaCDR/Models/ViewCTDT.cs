using System.ComponentModel.DataAnnotations;

namespace DanhgiaCDR.Models
{
    public class ViewCTDT
    {
        [Key]
        public int CTDT_ID { get; set; }
        public string? CTDT_Ten { get; set; }
        public List<ViewHP> tblMHs { get; set; } = null!;
    }
}
