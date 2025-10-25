namespace Core.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public string? Sku { get; set; }
        public List<ImageDto> Images { get; set; } = [];
    }
}
