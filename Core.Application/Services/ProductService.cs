using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto?> GetBySlugAsync(string slug)
        {
            var product = await _context.Products
                .Include(m => m.ProductImages)
                .FirstOrDefaultAsync(m => m.Slug == slug);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}
