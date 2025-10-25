using Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Vue.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IShopService _shopService;

        public ShopController(ILogger<ShopController> logger, IShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _shopService.GetShopAsync();

            return View(result);
        }
    }
}