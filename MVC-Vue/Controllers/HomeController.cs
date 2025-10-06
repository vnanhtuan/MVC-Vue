using Microsoft.AspNetCore.Mvc;

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
            List<Product> _products = [];

            _products.Add(new Product
            {
                Id = 1,
                Name = "ao phong",
                Price = 199000
            });
            _products.Add(new Product
            {
                Id = 2,
                Name = "ao khoac",
                Price = 199000
            });
            _products.Add(new Product
            {
                Id = 3,
                Name = "Quan short",
                Price = 199000
            });

            List<Image> _images = [];

            _images.Add(new Image
            {
                Id = 1,
                Name = "Summer Vibes 2025",
                Url = "/slide-1.jpg"
            });
            _images.Add(new Image
            {
                Id = 2,
                Name = "Street Style",
                Url = "https://cdn.vuetifyjs.com/images/cards/hotel.jpg"
            });
            _images.Add(new Image
            {
                Id = 3,
                Name = "Sport Collection",
                Url = "https://cdn.vuetifyjs.com/images/cards/sunshine.jpg"
            });

            var result = new HomeDto
            {
                Products = _products,
                Images = _images
            };

            return View(result);
        }
    }

    public class HomeDto
    {
        public List<Product> Products { get; set; } = [];
        public List<Image> Images { get; set; } = [];
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Image
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

}
