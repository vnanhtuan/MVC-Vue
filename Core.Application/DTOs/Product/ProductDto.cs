namespace Core.Application.DTOs.Product
{
    public class ProductDto: ProductBase
    {
        public List<ImageDto> Images { get; set; } = [];
    }
}
