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
    public IActionResult Index(string slug)
    {
      if (string.IsNullOrEmpty(slug))
      {
          return BadRequest();
      }
      Product product = ProductDatabase.GetProductBySlug(slug) ?? new Product();
      return View("Product", product);
    }
  }
}