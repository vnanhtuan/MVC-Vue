using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetBySlugAsync(string slug);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<PaginatedResult<ProductListDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
    }
}
