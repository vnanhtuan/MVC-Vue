using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Core.Application.Services
{
    public class HomeService: IHomeService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public HomeService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HomeDto> GetHomePage()
        {
            var result = new HomeDto();
            var categories = await _context.Categories.ToListAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            foreach (var category in categoryDtos)
            {
                var products = await _context.Products
                    .Include(p => p.ProductImages)
                    .Where(p => p.CategoryId == category.Id)
                    .OrderBy(p => p.Id)                     
                    .Skip(0)
                    .Take(15)
                    .AsNoTracking()
                    .ToListAsync();

                var productDtos = _mapper.Map<List<ProductDto>>(products);
                category.Products = productDtos;
            }

            result.Categories = categoryDtos;

            return result;
        }
    }
}
