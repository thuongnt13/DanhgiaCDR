using Microsoft.AspNetCore.Mvc;
using DanhgiaCDR.Models;
using System;
using System.Linq;

namespace DanhgiaCDR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSVController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminSVController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult dsSinhvien()
        {
            try
            {
                var dsSinhvien = (from sv in _context.tblSVs            
                                  select new
                                  {
                                      SV_ID = sv.SV_ID,
                                      SV_Ten = sv.SV_Ten,
                                      NGANH_ID = sv.NGANH_ID,
                                      CTDT_ID = sv.CTDT_ID,
                                      LHP_ID = sv.LHP_ID,
                                      MH_ID = sv.MH_ID

                                  }).ToList();
                return Json(new { code = 200, dsSinhvien = dsSinhvien, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // HÀM THÊM MỚI 

        [HttpPost]
        public JsonResult Create(int SV_ID, string SV_Ten, int NGANH_ID, int CTDT_ID, int LHP_ID, int MH_ID)
        {
            try
            {


                var sv = new tblSV();
                sv.SV_ID = SV_ID;
                sv.SV_Ten = SV_Ten;
                sv.NGANH_ID = NGANH_ID;
                sv.CTDT_ID = CTDT_ID;
                sv.LHP_ID = LHP_ID;
                sv.MH_ID = MH_ID;

                _context.tblSVs.Add(sv);
                _context.SaveChanges();


                return Json(new { code = 200, msg = "Thêm mới thành công" });


            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới thất bại. Lỗi: " + ex.Message });
            }
        }

        //hàm xem chi tiết
        [HttpGet]
        public JsonResult Details(int id)
        {
            try
            {
                var sv = _context.tblSVs.FirstOrDefault(x => x.SV_ID == id);

                return Json(new { code = 200, sv = sv, msg = "Lấy thông tin thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại. Lỗi: " + ex.Message });
            }
        }
        // CHỈNH SỬA

        [HttpPost]

        public JsonResult Edit(int id, string SV_Ten, int NGANH_ID, int CTDT_ID, int LHP_ID, int MH_ID)
        {
            try
            {
                var sv = _context.tblSVs.SingleOrDefault(x => x.SV_ID == id);

                sv.SV_Ten = SV_Ten;
                sv.NGANH_ID = NGANH_ID;
                sv.CTDT_ID = CTDT_ID;
                sv.LHP_ID = LHP_ID;
                sv.MH_ID = MH_ID;
                //Lưu vào csdl
                _context.Update(sv);
                _context.SaveChanges();

                return Json(new { code = 200, msg = "Cập nhật thành công" });

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Cập nhật thất bại: " + ex.Message });
            }
        }
        /// XÓA 
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var svs = _context.tblSVs.SingleOrDefault(x => x.SV_ID == id);

                //Films.IsActive = false;
                _context.Remove(svs);
                _context.SaveChanges();

                return Json(new { code = 200, msg = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Xóa thất bại: " + ex.Message });
            }
        }
    }
}
