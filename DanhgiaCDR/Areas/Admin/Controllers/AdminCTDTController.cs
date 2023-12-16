using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanhgiaCDR.Models;

namespace DanhgiaCDR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCTDTController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminCTDTController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        // GET: Admin/tblCTDTs
        public async Task<IActionResult> Index()
        {
              return _context.tblCTDTs != null ? 
                          View(await _context.tblCTDTs.ToListAsync()) :
                          Problem("Entity set 'dbDanhgiaCDRContext.tblCTDTs'  is null.");
        }
        //
        [HttpGet]
        public JsonResult AllCTDT()
        {
            try
            {
                var allCTDT = (from n in _context.tblCTDTs.Where(x => x.IsActive == true)
                                select new
                                {
                                    CTDT_ID = n.CTDT_ID,
                                    CTDT_Ten = n.CTDT_Ten
                                }).ToList();
                return Json(new { code = 200, allCTDT = allCTDT, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // GET: Admin/tblCTDTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblCTDTs == null)
            {
                return NotFound();
            }

            var tblCTDT = await _context.tblCTDTs
                .FirstOrDefaultAsync(m => m.CTDT_ID == id);
            if (tblCTDT == null)
            {
                return NotFound();
            }

            return View(tblCTDT);
        }

        // GET: Admin/tblCTDTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblCTDTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CTDT_ID,CTDT_Ten,NGANH_ID,CTDT_So,DV_ID,CTDT_SoTinChi,CTDT_NamBatDau,CTDT_ThoiGianToiDa,CTDT_ThoiGianToiThieu,CTDT_GhiChu,CTDT_File")] tblCTDT tblCTDT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCTDT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCTDT);
        }

        // GET: Admin/tblCTDTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblCTDTs == null)
            {
                return NotFound();
            }

            var tblCTDT = await _context.tblCTDTs.FindAsync(id);
            if (tblCTDT == null)
            {
                return NotFound();
            }
            return View(tblCTDT);
        }

        // POST: Admin/tblCTDTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CTDT_ID,CTDT_Ten,NGANH_ID,CTDT_So,DV_ID,CTDT_SoTinChi,CTDT_NamBatDau,CTDT_ThoiGianToiDa,CTDT_ThoiGianToiThieu,CTDT_GhiChu,CTDT_File")] tblCTDT tblCTDT)
        {
            if (id != tblCTDT.CTDT_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCTDT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCTDTExists(tblCTDT.CTDT_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblCTDT);
        }

        // GET: Admin/tblCTDTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblCTDTs == null)
            {
                return NotFound();
            }

            var tblCTDT = await _context.tblCTDTs
                .FirstOrDefaultAsync(m => m.CTDT_ID == id);
            if (tblCTDT == null)
            {
                return NotFound();
            }

            return View(tblCTDT);
        }

        // POST: Admin/tblCTDTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblCTDTs == null)
            {
                return Problem("Entity set 'dbDanhgiaCDRContext.tblCTDTs'  is null.");
            }
            var tblCTDT = await _context.tblCTDTs.FindAsync(id);
            if (tblCTDT != null)
            {
                _context.tblCTDTs.Remove(tblCTDT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCTDTExists(int id)
        {
          return (_context.tblCTDTs?.Any(e => e.CTDT_ID == id)).GetValueOrDefault();
        }
    }
}
