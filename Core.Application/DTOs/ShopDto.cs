using Core.Application.DTOs.Category;
using Core.Application.DTOs.Product;

namespace Core.Application.DTOs
{
    public class ShopDto
    {
        public List<CategoryDto> Categories { get; set; } = [];
        public List<ProductDto> Products { get; set; } = [];
    }
}
