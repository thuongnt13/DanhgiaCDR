using DanhgiaCDR.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanhgiaCDR.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private dbDanhgiaCDRContext _context;
        public MenuViewComponent(dbDanhgiaCDRContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) 
                              select m).ToList();


            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));

        }
    }
}
