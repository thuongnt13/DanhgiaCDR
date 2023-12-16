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
    public class AdminLHPController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminLHPController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLHP
        public async Task<IActionResult> Index()
        {
              return _context.tblLHPs != null ? 
                          View(await _context.tblLHPs.ToListAsync()) :
                          Problem("Entity set 'dbDanhgiaCDRContext.tblLHPs'  is null.");
        }
        //lấy danh sách cho thẻ selec
        [HttpGet]
        public JsonResult AllLHP()
        {
            try
            {
                var allLHP = (from n in _context.tblLHPs.Where(x => x.IsActive == true)
                             select new
                             {
                                 LHP_ID = n.LHP_ID,
                                 LHP_Ten = n.LHP_Ten
                             }).ToList();
                return Json(new { code = 200, allLHP = allLHP, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // GET: Admin/AdminLHP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblLHPs == null)
            {
                return NotFound();
            }

            var tblLHP = await _context.tblLHPs
                .FirstOrDefaultAsync(m => m.LHP_ID == id);
            if (tblLHP == null)
            {
                return NotFound();
            }

            return View(tblLHP);
        }

        // GET: Admin/AdminLHP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLHP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LHP_ID,GV_ID,MH_ID,LHP_Ten")] tblLHP tblLHP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLHP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblLHP);
        }

        // GET: Admin/AdminLHP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblLHPs == null)
            {
                return NotFound();
            }

            var tblLHP = await _context.tblLHPs.FindAsync(id);
            if (tblLHP == null)
            {
                return NotFound();
            }
            return View(tblLHP);
        }

        // POST: Admin/AdminLHP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LHP_ID,GV_ID,MH_ID,LHP_Ten")] tblLHP tblLHP)
        {
            if (id != tblLHP.LHP_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLHP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblLHPExists(tblLHP.LHP_ID))
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
            return View(tblLHP);
        }

        // GET: Admin/AdminLHP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblLHPs == null)
            {
                return NotFound();
            }

            var tblLHP = await _context.tblLHPs
                .FirstOrDefaultAsync(m => m.LHP_ID == id);
            if (tblLHP == null)
            {
                return NotFound();
            }

            return View(tblLHP);
        }

        // POST: Admin/AdminLHP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblLHPs == null)
            {
                return Problem("Entity set 'dbDanhgiaCDRContext.tblLHPs'  is null.");
            }
            var tblLHP = await _context.tblLHPs.FindAsync(id);
            if (tblLHP != null)
            {
                _context.tblLHPs.Remove(tblLHP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblLHPExists(int id)
        {
          return (_context.tblLHPs?.Any(e => e.LHP_ID == id)).GetValueOrDefault();
        }
    }
}
