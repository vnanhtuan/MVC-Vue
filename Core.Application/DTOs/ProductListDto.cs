using Core.Application.DTOs.Product;

namespace Core.Application.DTOs
{
    public class ProductListDto: ProductBase
    {
        public string MainImageUrl { get; set; } = "";
    }
}
