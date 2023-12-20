using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanhgiaCDR.Models;

namespace DanhgiaCDR.Controllers
{
    public class DanhSachController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;

        public DanhSachController(dbDanhgiaCDRContext context)
        {
           _context = context;
        }

        public ActionResult Index(int MH_ID)
        {
            var danhSach = (from mh in _context.tblMHs
                            join sv in _context.tblSVs on mh.MH_ID equals sv.MH_ID
                            join ctdt in _context.tblCTDTs on mh.CTDT_ID equals ctdt.CTDT_ID
                            join nganh in _context.tblNganhs on mh.NGANH_ID equals nganh.NGANH_ID
                            join loaiPhieu in _context.tblLoaiPhieus on mh.MH_ID equals loaiPhieu.MH_ID
                            where mh.MH_ID == MH_ID
                            select new View_Danhsach
                            {
                                SV_ID = sv.SV_ID,
                                SV_Ten = sv.SV_Ten,
                                CTDT_ID = ctdt.CTDT_ID,
                                CTDT_Ten = ctdt.CTDT_Ten,
                                NGANH_ID = mh.NGANH_ID,
                                NGANH_Ten = nganh.NGANH_Ten,
                                LoaiPhieuDanhGia_ID = loaiPhieu.LoaiPhieuDanhGia_ID,
                                PhieuDanhGia_Ten = loaiPhieu.PhieuDanhGia_Ten,
                                MH_ID = mh.MH_ID,
                                MH_Ten = mh.MH_Ten
                            })
                    .ToList();

            return View(danhSach);
        }
    }
}
