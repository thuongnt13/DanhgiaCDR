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

        public ActionResult Index(int TieuChi_ID)
        {
            /* if (string.IsNullOrEmpty(TieuChi_ID.ToString()))
            {
                var fullList = _context.view_Loaiphieu.OrderBy(d => d.SV_ID).ToList();
                return View(fullList);
            }
            else
            {
                var query = _context.view_Loaiphieu
                            .Where(item => item.TieuChi_ID == TieuChi_ID).ToList();
                return View(query);

            }


        }*/
            var listofTieuchi = (from t in _context.view_Loaiphieu
                                 where (t.IsActive == true)
                                 select t).ToList();


            return View(listofTieuchi);


        }
    }
}
