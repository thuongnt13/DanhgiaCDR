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
            if (string.IsNullOrEmpty(MH_ID.ToString()))
            {
                var fullList = _context.tblSVs.OrderBy(d => d.SV_ID).ToList();
                return View(fullList);
            }
            else
            {
                Console.WriteLine(MH_ID);
                var query = _context.view_Danhsach
                            .Where(item => item.MH_ID == MH_ID).ToList();
                return View(query);

            }


        }
    }
}