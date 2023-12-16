using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DanhgiaCDR.Controllers
{
    public class DanhgiaController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public DanhgiaController(dbDanhgiaCDRContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index(string tenhocphan)
        {
            // Nếu có giá trị tên học phần được truyền vào, thực hiện tìm kiếm
            if (!string.IsNullOrEmpty(tenhocphan))
            {
                var dgList = _context.tblMHs
                    .Where(d => d.MH_Ten.Contains(tenhocphan))
                    .OrderBy(d => d.MH_ID)
                    .ToList();

                // Kiểm tra nếu có kết quả
                if (dgList.Count > 0)
                {
                    return View(dgList);
                }
                else
                {
                    // Nếu không có kết quả, thêm thông báo vào ViewBag
                    ViewBag.Message = "Không tìm thấy học phần.";
                    return View(new List<tblMH>());
                }
            }

            // Nếu không có tên học phần, hiển thị toàn bộ danh sách
            var fullList = _context.tblMHs.OrderBy(d => d.MH_ID).ToList();
            return View(fullList);
        }

    }
}
