namespace Core.Application.DTOs
{
    public class PaginatedResult<T>
    {
        public required List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
