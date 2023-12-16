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
    public class AdminNganhController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminNganhController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        // GET: Admin/tblNganhs
        public async Task<IActionResult> Index()
        {
              return _context.tblNganhs != null ? 
                          View(await _context.tblNganhs.ToListAsync()) :
                          Problem("Entity set 'dbDanhgiaCDRContext.tblNganhs'  is null.");
        }
        [HttpGet]
        public JsonResult AllNganh()
        {
            try
            {
                var allNganh = (from n in _context.tblNganhs.Where(x => x.IsActive == true)
                                select new
                                {
                                    NGANH_ID = n.NGANH_ID,
                                    NGANH_Ten = n.NGANH_Ten
                                }).ToList();
                return Json(new { code = 200, allNganh = allNganh, msg = "Lấy danh sách ngành thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách ngành thất bại: " + ex.Message });
            }
        }

        // GET: Admin/tblNganhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblNganhs == null)
            {
                return NotFound();
            }

            var tblNganh = await _context.tblNganhs
                .FirstOrDefaultAsync(m => m.NGANH_ID == id);
            if (tblNganh == null)
            {
                return NotFound();
            }

            return View(tblNganh);
        }

        // GET: Admin/tblNganhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/tblNganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NGANH_ID,DV_ID,NGANH_Ten,NGANH_TenE,NGANH_Cap,NGANH_ID_Cha,NGANH_ThoiGianToiThieu,NGANH_ThoiGianToiDa,IsActive")] tblNganh tblNganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblNganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblNganh);
        }

        // GET: Admin/tblNganhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblNganhs == null)
            {
                return NotFound();
            }

            var tblNganh = await _context.tblNganhs.FindAsync(id);
            if (tblNganh == null)
            {
                return NotFound();
            }
            return View(tblNganh);
        }

        // POST: Admin/tblNganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NGANH_ID,DV_ID,NGANH_Ten,NGANH_TenE,NGANH_Cap,NGANH_ID_Cha,NGANH_ThoiGianToiThieu,NGANH_ThoiGianToiDa,IsActive")] tblNganh tblNganh)
        {
            if (id != tblNganh.NGANH_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblNganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblNganhExists(tblNganh.NGANH_ID))
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
            return View(tblNganh);
        }

        // GET: Admin/tblNganhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblNganhs == null)
            {
                return NotFound();
            }

            var tblNganh = await _context.tblNganhs
                .FirstOrDefaultAsync(m => m.NGANH_ID == id);
            if (tblNganh == null)
            {
                return NotFound();
            }

            return View(tblNganh);
        }

        // POST: Admin/tblNganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblNganhs == null)
            {
                return Problem("Entity set 'dbDanhgiaCDRContext.tblNganhs'  is null.");
            }
            var tblNganh = await _context.tblNganhs.FindAsync(id);
            if (tblNganh != null)
            {
                _context.tblNganhs.Remove(tblNganh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblNganhExists(int id)
        {
          return (_context.tblNganhs?.Any(e => e.NGANH_ID == id)).GetValueOrDefault();
        }
    }
}
