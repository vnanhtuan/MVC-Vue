using Core.Application.DTOs;
using Core.Application.DTOs.Product;

namespace Core.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetBySlugAsync(string slug);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<PaginatedResult<ProductListDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
        Task<ProductDto> CreateProductAsync(ProductCreateDto dto);
        Task UpdateProductAsync(int id, ProductUpdateDto dto);
    }
}
