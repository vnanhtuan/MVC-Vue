using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Services
{
    public class CategoryService: ICategoryService
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
    }
}
