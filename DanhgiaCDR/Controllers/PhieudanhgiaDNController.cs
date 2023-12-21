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

        public IActionResult Index()
        {
            return View();
        }
        //LẤY DANH SÁCH
        //sửa lại thành view
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
        public JsonResult Create(int SV_ID, float DiemHe10, float DiemNangLuc, float HonMongDoi, string GhiChu, int TieuChi_ID)
        {
            try
            {


                var nl = new tblDanhGiaNangLuc();
                
                nl.SV_ID = SV_ID;
                nl.DiemHe10 = DiemHe10;
                nl.DiemNangLuc = DiemNangLuc;
                nl.HonMongDoi = HonMongDoi;
                nl.GhiChu = GhiChu;
                nl.TieuChi_ID = TieuChi_ID;

                _context.tblDanhGiaNangLucs.Add(nl);
                _context.SaveChanges();


                return Json(new { code = 200, msg = "Thêm mới thành công" });


            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới thất bại. Lỗi: " + ex.Message });
            }
        }

    }
}
