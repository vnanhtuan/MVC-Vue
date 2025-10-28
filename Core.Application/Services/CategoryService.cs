using AutoMapper;
using Core.Application.DTOs.Category;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MVC_Vue.Helpers;

namespace Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Category not found");
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CategoryDto> CreateAsync(CategoryCreateDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            category.Slug = category.Name.GenerateSlug();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
        public async Task UpdateAsync(int id, CategoryUpdateDto dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Category not found");

            _mapper.Map(dto, category);
            category.Slug = category.Name.GenerateSlug();

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Exception("Category not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
