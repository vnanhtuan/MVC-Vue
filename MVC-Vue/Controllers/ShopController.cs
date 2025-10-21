using Microsoft.AspNetCore.Mvc;
using MVC_Vue.Databases;

namespace MVC_Vue.Controllers
{
    public class ShopController : Controller
    {
      private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          List<Category> _categories = CategoryDatabase.GetCategories();
          List<Product> _products = ProductDatabase.GetProducts();
          var viewModel = new ShopViewModel
          {
              Categories = _categories,
              Products = _products
          };

          // 3. Truyền ViewModel xuống View
          return View(viewModel);
        }
    }
}