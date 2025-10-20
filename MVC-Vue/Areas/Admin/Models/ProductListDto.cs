namespace MVC_Vue.Areas.Admin.Models
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } // "Còn hàng" hoặc "Hết hàng"
        public string Sizes { get; set; } // "S, M, L"
    }
}
