using Core.Application.DTOs.Category;

namespace Core.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryCreateDto dto);
        Task UpdateAsync(int id, CategoryUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
