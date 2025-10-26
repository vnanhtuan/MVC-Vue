using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<PaginatedResult<ProductListDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var totalItems = await _context.Products.CountAsync();

            var products = await _context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider) //// <-- Performance just get 1 image
                .ToListAsync();

            var result = new PaginatedResult<ProductListDto>
            {
                Items = products,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(m => m.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
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
