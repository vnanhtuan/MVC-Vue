using Core.Application.DTOs.Product;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Vue.Controllers
{
    public class ProductController : Controller
  {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
    public async Task<IActionResult> Index(string slug)
    {
      if (string.IsNullOrEmpty(slug))
      {
          return BadRequest();
      }
      var product = await _productService.GetBySlugAsync(slug) ?? new ProductDto();
      return View("Product", product);
    }
  }
}