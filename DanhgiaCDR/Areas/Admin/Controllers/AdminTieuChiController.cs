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
    public class AdminTieuChiController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public AdminTieuChiController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        //
        public async Task<IActionResult> Index()
        {
              return View();
        }
        //LẤY DANH SÁCH
        [HttpGet]
        public JsonResult DsTieuchi()
        {
            try
            {
                var dsTieuchi = (from tc in _context.tblTieuChis.OrderByDescending(x => x.TieuChi_ID)
                                 select new
                                  {
                                      TieuChi_ID = tc.TieuChi_ID,
                                      LoaiPhieuDanhGia_ID = tc.LoaiPhieuDanhGia_ID,
                                      TieuChi_Ten = tc.TieuChi_Ten,
                                      KhoangDiemmin = tc.KhoangDiemmin,
                                      KhoangDiemmax = tc.KhoangDiemmax,
                                      DongGopCDR = tc.DongGopCDR,
                                      TrongSo = tc.TrongSo,
                                      CDRMH_ID = tc.CDRMH_ID,
                                      TieuChi_Cap = tc.TieuChi_Cap,
                                      TieuChi_Cha = tc.TieuChi_Cha,
                                      IsActve = tc.IsActve,
                                      ThuTu = tc.ThuTu

                                 }).ToList();
                return Json(new { code = 200, dsTieuchi = dsTieuchi, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // HÀM THÊM MỚI 

        [HttpPost]
        public JsonResult Create(int LoaiPhieuDanhGia_ID, string TieuChi_Ten, float KhoangDiemmin, float KhoangDiemmax, int DongGopCDR, float TrongSo, int CDRMH_ID, int TieuChi_Cap, int TieuChi_Cha, bool IsActve, int ThuTu)
        {
            try
            {


                var tc = new tblTieuChi();
                tc.LoaiPhieuDanhGia_ID = LoaiPhieuDanhGia_ID;
                tc.TieuChi_Ten = TieuChi_Ten;
                tc.KhoangDiemmin = KhoangDiemmin;
                tc.KhoangDiemmax = KhoangDiemmax;
                tc.DongGopCDR = DongGopCDR;
                tc.TrongSo = TrongSo;
                tc.CDRMH_ID = CDRMH_ID; 
                tc.TieuChi_Cap = TieuChi_Cap;
                tc.TieuChi_Cha = TieuChi_Cha;
                tc.IsActve = IsActve;
                tc.ThuTu = ThuTu;

                _context.tblTieuChis.Add(tc);
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
                var tc = _context.tblTieuChis.FirstOrDefault(x => x.TieuChi_ID == id);

                return Json(new { code = 200, tc = tc, msg = "Lấy thông tin thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại. Lỗi: " + ex.Message });
            }
        }
        // CHỈNH SỬA

        [HttpPost]

        public JsonResult Edit(int id, int LoaiPhieuDanhGia_ID, string TieuChi_Ten, float KhoangDiemmin, float KhoangDiemmax, int DongGopCDR, float TrongSo, int CDRMH_ID, int TieuChi_Cap, int TieuChi_Cha, bool IsActve, int ThuTu)
        {
            try
            {
                var tc = _context.tblTieuChis.SingleOrDefault(x => x.TieuChi_ID == id);

                tc.LoaiPhieuDanhGia_ID = LoaiPhieuDanhGia_ID;
                tc.TieuChi_Ten = TieuChi_Ten;
                tc.KhoangDiemmin = KhoangDiemmin;
                tc.KhoangDiemmax = KhoangDiemmax;
                tc.DongGopCDR = DongGopCDR;
                tc.TrongSo = TrongSo;
                tc.CDRMH_ID = CDRMH_ID;
                tc.TieuChi_Cap = TieuChi_Cap;
                tc.TieuChi_Cha = TieuChi_Cha;
                tc.IsActve = IsActve;
                tc.ThuTu = ThuTu;
                
                //Lưu vào csdl
                _context.Update(tc);
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
                var tcs = _context.tblTieuChis.SingleOrDefault(x => x.TieuChi_ID == id);

                //Films.IsActive = false;
                _context.Remove(tcs);
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
