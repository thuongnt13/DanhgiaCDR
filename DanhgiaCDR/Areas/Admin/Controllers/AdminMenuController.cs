using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanhgiaCDR.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMenuController : Controller
    {
        private readonly dbDanhgiaCDRContext _context;
        public AdminMenuController(dbDanhgiaCDRContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var mnList = _context.Menus.OrderBy(m=>m.MenuID).ToList();
            //return View(mnList);
            return View();
        }

        // Lấy danh sách bằng AJAX
        [HttpGet]
        public JsonResult DsMenu(int trang)
        {
            try
            {
               

                var dsMenu = (from mn in _context.Menus.OrderByDescending(x => x.MenuID)
                              select new
                              {
                                  MenuID = mn.MenuID,
                                  MenuName = mn.MenuName,
                                  Levels = mn.Levels,
                                  ParentID = mn.ParentID,
                                  MenuOrder = mn.MenuOrder,
                                  IsActive = mn.IsActive

                              }).ToList();




                return Json(new { code = 200, dsMenu = dsMenu, msg = "Lấy danh sách menu thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách menu thất bại: " + ex.Message });
            }
        }

        // Lấy all danh sách menu để sử dụng cho thẻ select 

        public JsonResult AllMenu()
        {
            try
            {
                var allMenu = (from mn in _context.Menus.Where(x => x.IsActive == true)
                               select new
                               {
                                   MenuID = mn.MenuID,
                                   MenuName = mn.MenuName
                               }).ToList();



                return Json(new { code = 200, allMenu = allMenu, msg = "Lấy danh sách thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy danh sách thất bại: " + ex.Message });
            }
        }
        // Hàm Json thêm mới
        [HttpPost]

        public JsonResult Create(string menuName, int ParentID, int categoryID, int levels, int menuOrder, int position, bool isActive)
        {
            try
            {
                var Menus = new Menu();
                Menus.MenuName = menuName;
                Menus.ParentID = ParentID;
                Menus.Levels = levels;
                Menus.MenuOrder = menuOrder;
                Menus.IsActive = isActive;

                _context.Menus.Add(Menus);
                _context.SaveChanges();


                return Json(new { code = 200, msg = "Thêm mới thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới thất bại!. Lỗi: " + ex.Message });

            }
        }


        // XEM CHI TIẾT MENU

        [HttpGet]
        public JsonResult Details(int id)
        {
            try
            {
                var Menus = _context.Menus.FirstOrDefault(x => x.MenuID == id);

                return Json(new { code = 200, Menus = Menus, msg = "Lấy thông tin menu thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin thất bại. Lỗi: " + ex.Message });
            }
        }


        // Chỉnh sửa menu

        [HttpPost]

        public JsonResult Edit(int id, string menuName, int ParentID, int categoryID, int levels, int menuOrder, int position, bool isActive)
        {
            try
            {
                var Menus = _context.Menus.SingleOrDefault(x => x.MenuID == id);
                Menus.MenuName = menuName;
                Menus.ParentID = ParentID;
                Menus.Levels = levels;
                Menus.MenuOrder = menuOrder;
                Menus.IsActive = isActive;

                //Lưu vào csdl
                _context.Update(Menus);
                _context.SaveChanges();

                return Json(new { code = 200, msg = "Cập nhật menu thành công" });

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Cập nhật menu thất bại: " + ex.Message });
            }
        }

        /// XÓA MENU
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var Menus = _context.Menus.SingleOrDefault(x => x.MenuID == id);

                _context.Remove(Menus);
                _context.SaveChanges();

                return Json(new { code = 200, msg = "Xóa menu thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Xóa menu thất bại: " + ex.Message });
            }
        }

    }
}
