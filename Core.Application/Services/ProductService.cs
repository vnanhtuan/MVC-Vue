using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.DTOs;
using Core.Application.DTOs.Product;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MVC_Vue.Helpers;

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
        public async Task<ProductDto> CreateProductAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Slug = product.Name.GenerateSlug();

            if (product.ProductImages.Any())
            {
                product.ProductImages.First().IsMain = true;
            }

            try
            {
                await _context.Products.AddAsync(product);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
                var message = ex.Message;

                return null;
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(int id, ProductUpdateDto dto)
        {
            // 1. Tìm Product trong DB (phải Include cả Images)
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _context.ProductImages.RemoveRange(product.ProductImages);

            _mapper.Map(dto, product);
            product.Slug = product.Name.GenerateSlug(product.Id.ToString());

            if (product.ProductImages.Any())
            {
                product.ProductImages.First().IsMain = true;
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
