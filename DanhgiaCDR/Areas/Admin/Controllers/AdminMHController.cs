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
    public class AdminMHController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminMHController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        // GET: Admin/tblMHs
        public async Task<IActionResult> Index()
        {
            var dbDanhgiaCDRContext = _context.tblMHs.Include(t => t.CTDT);
            return View(await dbDanhgiaCDRContext.ToListAsync());
        }
        //lấy danh sách cho thẻ selec
        [HttpGet]
        public JsonResult AllMH()
        {
            try
            {
                var allMH = (from n in _context.tblMHs.Where(x => x.IsActive == true)
                               select new
                               {
                                   MH_ID = n.MH_ID,
                                   MH_Ten = n.MH_Ten
                               }).ToList();
                return Json(new { code = 200, allMH = allMH, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // GET: Admin/tblMHs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblMHs == null)
            {
                return NotFound();
            }

            var tblMH = await _context.tblMHs
                .Include(t => t.CTDT)
                .FirstOrDefaultAsync(m => m.MH_ID == id);
            if (tblMH == null)
            {
                return NotFound();
            }

            return View(tblMH);
        }

        // GET: Admin/tblMHs/Create
        public IActionResult Create()
        {
            ViewData["CTDT_ID"] = new SelectList(_context.tblCTDTs, "CTDT_ID", "CTDT_ID");
            return View();
        }

        // POST: Admin/tblMHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MH_ID,MH_Ten,MH_SoTinChi,NGANH_ID,CTDT_ID")] tblMH tblMH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CTDT_ID"] = new SelectList(_context.tblCTDTs, "CTDT_ID", "CTDT_ID", tblMH.CTDT_ID);
            return View(tblMH);
        }

        // GET: Admin/tblMHs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblMHs == null)
            {
                return NotFound();
            }

            var tblMH = await _context.tblMHs.FindAsync(id);
            if (tblMH == null)
            {
                return NotFound();
            }
            ViewData["CTDT_ID"] = new SelectList(_context.tblCTDTs, "CTDT_ID", "CTDT_ID", tblMH.CTDT_ID);
            return View(tblMH);
        }

        // POST: Admin/tblMHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MH_ID,MH_Ten,MH_SoTinChi,NGANH_ID,CTDT_ID")] tblMH tblMH)
        {
            if (id != tblMH.MH_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblMHExists(tblMH.MH_ID))
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
            ViewData["CTDT_ID"] = new SelectList(_context.tblCTDTs, "CTDT_ID", "CTDT_ID", tblMH.CTDT_ID);
            return View(tblMH);
        }

        // GET: Admin/tblMHs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblMHs == null)
            {
                return NotFound();
            }

            var tblMH = await _context.tblMHs
                .Include(t => t.CTDT)
                .FirstOrDefaultAsync(m => m.MH_ID == id);
            if (tblMH == null)
            {
                return NotFound();
            }

            return View(tblMH);
        }

        // POST: Admin/tblMHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblMHs == null)
            {
                return Problem("Entity set 'dbDanhgiaCDRContext.tblMHs'  is null.");
            }
            var tblMH = await _context.tblMHs.FindAsync(id);
            if (tblMH != null)
            {
                _context.tblMHs.Remove(tblMH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblMHExists(int id)
        {
          return (_context.tblMHs?.Any(e => e.MH_ID == id)).GetValueOrDefault();
        }
    }
}
