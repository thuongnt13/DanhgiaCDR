using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanhgiaCDR.Models;
using System.Linq;
using DanhgiaCDR.Areas.Admin.Models;
namespace DanhgiaCDR.Components
{
    [ViewComponent(Name = "Danhgia")]
    public class DanhgiaComponents : ViewComponent
    {
        private readonly dbDanhgiaCDRContext _context;

        public DanhgiaComponents(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchName)
        {
            // Thực hiện truy vấn tìm kiếm môn học theo tên
            var listOfHPs = await _context.tblMHs
                .Where(hp => string.IsNullOrEmpty(searchName) || hp.MH_Ten.Contains(searchName))
                .ToListAsync();

            return View("DanhgiaDefault", listOfHPs);
        }
    }
}
