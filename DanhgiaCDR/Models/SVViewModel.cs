using System.Collections.Generic;
namespace DanhgiaCDR.Models
{
    public class SVViewModel
    {
        public tblSV Student { get; set; }
        public tblNganh Major { get; set; }
        public tblCTDT Curriculum { get; set; }
        public tblLoaiPhieu EvaluationType { get; set; }
        public List<tblMH> Courses { get; set; }
    }  
}
