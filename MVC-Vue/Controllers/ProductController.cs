using Microsoft.AspNetCore.Mvc;
using MVC_Vue.Databases;

namespace MVC_Vue.Controllers
{
  public class ProductController : Controller
  {
    private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
    public IActionResult Index(int id)
    {
      Product product = ProductDatabase.GetProductById(id) ?? new Product();
      return View("Product", product);
    }
  }
}