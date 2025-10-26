using Core.Application.DTOs.Product;

namespace Core.Application.DTOs
{
    public class ProductDto: ProductBase
    {
        public List<ImageDto> Images { get; set; } = [];
    }
}
