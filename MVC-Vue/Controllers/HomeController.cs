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
            var result = new HomeDto
            {
                Categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Sản phẩm mới",
                        Products = _products
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Sản phẩm Mùa hè",
                        Products = _products
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Sản phẩm Bán chạy",
                        Products = _products
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Sản phẩm giảm giá",
                        Products = _products
                    }
                },
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
