using Microsoft.AspNetCore.Mvc;
using MVC_Vue.Databases;

namespace MVC_Vue.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Fetch data
            List<MenuData> _menus = MenuDatabase.GetMenus();
            return View("MenuList", _menus); // Return the view and data
        }
    }
}
