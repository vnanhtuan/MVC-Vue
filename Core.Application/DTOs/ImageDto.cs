namespace Core.Application.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Url { get; set; } = null!;

        public bool IsMain { get; set; }

        public short? DisplayOrder { get; set; }
    }
}
