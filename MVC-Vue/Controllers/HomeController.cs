using Microsoft.AspNetCore.Mvc;
using MVC_Vue.Databases;

namespace MVC_Vue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> _products = ProductDatabase.GetProducts();
            List<Category> _categories = CategoryDatabase.GetCategories().Where(m => m.IsHome == true).ToList();
            foreach (var category in _categories)
            {
                category.Products = _products.Where(m => m.CategoryId == category.Id).ToList();
            }
            var result = new HomeDto
            {
                Categories = _categories
            };

            return View(result);
        }
    }



    public class HomeDto
    {
        public List<Category> Categories { get; set; } = [];
        public List<Image> Images { get; set; } = [];
    }
}
