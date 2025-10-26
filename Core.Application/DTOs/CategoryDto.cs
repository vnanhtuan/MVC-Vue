using Core.Application.DTOs.Product;

namespace Core.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public List<ProductDto> Products { get; set; } = [];
    }
}
