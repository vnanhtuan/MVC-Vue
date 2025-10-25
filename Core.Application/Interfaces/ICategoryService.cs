using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
    }
}
