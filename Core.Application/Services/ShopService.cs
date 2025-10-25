using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Services
{
    public class ShopService: IShopService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ShopService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShopDto> GetShopAsync()
        {
            var result = new ShopDto();
            var categories = await _context.Categories.ToListAsync();
            result.Categories = _mapper.Map<List<CategoryDto>>(categories);

            var products = await _context.Products
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .ToListAsync();
            result.Products = _mapper.Map<List<ProductDto>>(products);

            return result;
        }
    }
}
