using Microsoft.AspNetCore.Mvc;

namespace MVC_Vue.Areas.Admin.Controllers 
{
    [Area("Admin")]
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            // Trỏ đường dẫn tuyệt đối đến layout mới
            return View("~/Areas/Admin/Views/Shared/_AdminLayout.cshtml");
        }
    }
}