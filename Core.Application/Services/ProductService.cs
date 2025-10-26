using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.DTOs;
using Core.Application.DTOs.Product;
using Core.Application.Interfaces;
using Core.Domain.Entities;
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
        public async Task<ProductDto> CreateProductAsync(ProductCreateDto dto)
        {
            // 1. Map DTO sang Entity
            var product = _mapper.Map<Product>(dto);

            // TODO: Xử lý logic IsMain cho ảnh đầu tiên
            if (product.ProductImages.Any())
            {
                product.ProductImages.First().IsMain = true;
            }

            // 2. Thêm vào Context
            await _context.Products.AddAsync(product);

            // 3. Lưu vào DB
            await _context.SaveChangesAsync();

            // 4. Map lại sang DTO để trả về
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

            // 2. Xóa ảnh cũ (Cách đơn giản nhất)
            _context.ProductImages.RemoveRange(product.ProductImages);

            // 3. Dùng AutoMapper để cập nhật các trường
            // (DTO sẽ ghi đè lên 'product' có sẵn)
            _mapper.Map(dto, product);


            if (product.ProductImages.Any())
            {
                product.ProductImages.First().IsMain = true;
            }

            
            await _context.SaveChangesAsync();
        }
    }
}
