namespace Core.Application.DTOs.Product
{
    public class ProductCreateDto
	{
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = "";
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public List<ProductCreateImage> Images { get; set; } = [];
    }

    public class ProductCreateImage
    {
        public string Url { get; set; } = null!;
        public string PublicId { get; set; } = null!;
    }
}

