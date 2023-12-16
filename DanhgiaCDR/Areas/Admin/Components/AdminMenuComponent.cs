using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanhgiaCDR.Areas.Admin.Components
{
    [ViewComponent(Name ="AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly dbDanhgiaCDRContext _context;
        public AdminMenuComponent(dbDanhgiaCDRContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from mn in _context.AdminMenus
                          where (mn.IsActive == true)
                          select mn).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}
