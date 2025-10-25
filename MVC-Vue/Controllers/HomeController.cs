using Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Vue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _homeService.GetHomePage();

            return View(result);
        }
    }
}
