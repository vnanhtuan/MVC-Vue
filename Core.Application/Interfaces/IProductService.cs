using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetBySlugAsync(string slug);
    }
}
