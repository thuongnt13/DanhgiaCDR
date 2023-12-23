using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DanhgiaCDR.Controllers
{
    public class PhieudanhgiaDNController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public PhieudanhgiaDNController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        public ActionResult Index(int MH_ID, int SV_ID)
        {
            var model = new View_Loaiphieu();
            var listofTieuchi = (from t in _context.view_Loaiphieu
                                 where (t.IsActive && t.MH_ID == MH_ID && t.SV_ID == SV_ID)
                                 select t).ToList();

            return View(listofTieuchi);


        }
    }
}
