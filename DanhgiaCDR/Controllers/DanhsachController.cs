using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanhgiaCDR.Models;

namespace DanhgiaCDR.Controllers
{
    public class DanhSachController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public DanhSachController(dbDanhgiaCDRContext context)
        {
           _context = context;
        }

        public ActionResult Index(int MH_ID)
        {
            var query = _context.view_Danhsach
                .Where(item => item.MH_ID == MH_ID);

            Console.WriteLine($"Generated SQL Query: {query.ToQueryString()}");

            var danhSachItems = query
                .Select(item => new View_Danhsach
                {
                    SV_ID = item.SV_ID,
                    SV_Ten = item.SV_Ten,
                    CTDT_ID = item.CTDT_ID,
                    CTDT_Ten = item.CTDT_Ten,
                    NGANH_ID = item.NGANH_ID,
                    NGANH_Ten = item.NGANH_Ten,
                    LoaiPhieuDanhGia_ID = item.LoaiPhieuDanhGia_ID,
                    PhieuDanhGia_Ten = item.PhieuDanhGia_Ten,
                    MH_ID = item.MH_ID,
                    MH_Ten = item.MH_Ten
                })
                .ToList();

            return View(danhSachItems);
        }
    }
}
