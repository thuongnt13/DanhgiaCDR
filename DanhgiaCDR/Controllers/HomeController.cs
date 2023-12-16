using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DanhgiaCDR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbDanhgiaCDRContext _context;

        public HomeController(ILogger<HomeController> logger, dbDanhgiaCDRContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet("/list-{slug}-{id:int}.html", Name = "List")]
       /* public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = from c in _context.tblCTDTs
                       where c.CTDT_ID == id
                       orderby c.CTDT_ID
                       select new ViewCTDT
                       {
                           CTDT_Ten = c.CTDT_Ten,
                           tblMHs = (from p in _context.tblMHs
                                     where p.CTDT_ID == c.CTDT_ID
                                     orderby p.MH_ID
                                     select new ViewHP
                                     {
                                         MH_ID = p.MH_ID,
                                         MH_Ten = p.MH_Ten,
                                         MH_SoTinChi = p.MH_SoTinChi,
                                         NGANH_ID = p.NGANH_ID
                                     }).ToList()
                       };

            var listOfCTDTWithHPs = list.Where(c => c.tblMHs.Count > 0);

            if (listOfCTDTWithHPs == null)
            {
                return NotFound();
            }

            return View("List", listOfCTDTWithHPs.ToList());
        }*/

    }
}