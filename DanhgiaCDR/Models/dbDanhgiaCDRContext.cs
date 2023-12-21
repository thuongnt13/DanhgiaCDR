using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DanhgiaCDR.Areas.Admin.Models;

namespace DanhgiaCDR.Models
{
    public partial class dbDanhgiaCDRContext : DbContext
    {
        public dbDanhgiaCDRContext()
        {
        }

        public dbDanhgiaCDRContext(DbContextOptions<dbDanhgiaCDRContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tblMH>()
            .HasOne(mh => mh.CTDT)
            .WithMany(ctdt => ctdt.tblMHs)
            .HasForeignKey(mh => new { mh.CTDT_ID, mh.NGANH_ID }) // Xác định khóa ngoại cụ thể
            .HasPrincipalKey(ctdt => new { ctdt.CTDT_ID, ctdt.NGANH_ID }); // Xác định khóa chính của tblCTDT

            modelBuilder.Entity<tblSV>()
           .HasKey(p => new { p.SV_ID, p.MH_ID });
        }

        public DbSet<tblCDRCTDT> tblCDRCTDTs { get; set; } = null!;
        public DbSet<tblCDRMH> tblCDRMHs { get; set; } = null!;
        public DbSet<tblCTDT> tblCTDTs { get; set; } = null!;
        public DbSet<tblCTDTMH> tblCTDTMHs { get; set; } = null!;
        public DbSet<tblDanhGiaNangLuc> tblDanhGiaNangLucs { get; set; } = null!;
        public DbSet<tblDonVi> tblDonVis { get; set; } = null!;
        public DbSet<tblGV> tblGVs { get; set; } = null!;
        public DbSet<tblLHP> tblLHPs { get; set; } = null!;
        public DbSet<tblLoaiPhieu> tblLoaiPhieus { get; set; } = null!;
        public DbSet<tblMH> tblMHs { get; set; } = null!;
        public DbSet<tblNangLuc> tblNangLucs { get; set; } = null!;
        public DbSet<tblNganh> tblNganhs { get; set; } = null!;
        public DbSet<tblSV> tblSVs { get; set; } = null!;
        public DbSet<tblTieuChi> tblTieuChis { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ViewCTDT> ViewCTDTs { get; set; } = null!;
        public DbSet<ViewHP> viewHPs { get; set; } = null!;
        //public DbSet<ViewSV> viewSVs { get; set; } = null!;
        //public DbSet<ViewLoaiPhieu> viewLoaiPhieus { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        //public DbSet<SVViewModel> SVViewModels { get; set;} = null!;
        public DbSet<View_Danhsach> view_Danhsach { get; set; } = null!;
        public DbSet<View_Loaiphieu> view_Loaiphieu { get; set; } = null!;
        //public DbSet<User> Users { get; set; } = null!;
        public DbSet<AdminMenu> AdminMenus { get; set; } = null!;

    }
}
