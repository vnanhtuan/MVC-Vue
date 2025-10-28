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
        private readonly IPhotoService _photoService;
        public ProductService(IAppDbContext context, IMapper mapper, IPhotoService photoService)
        {
            _context = context;
            _mapper = mapper;
            _photoService = photoService;
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

            // Ignored auto map ProductImages
            _mapper.Map(dto, product);

            product.Slug = product.Name.GenerateSlug(product.Id.ToString());

            // LOGIC compare image old and new
            var newImageDtos = dto.Images ?? [];
            var existingImages = product.ProductImages.ToList(); // Old image in DB

            var imagesToDelete = existingImages
            .Where(dbImg => !string.IsNullOrEmpty(dbImg.PublicId) &&
                            !newImageDtos.Any(dtoImg => dtoImg.PublicId == dbImg.PublicId))
            .ToList();

            var imagesToAdd = newImageDtos
            .Where(dtoImg => !existingImages.Any(dbImg => dbImg.PublicId == dtoImg.PublicId))
            .Select(dtoImg => _mapper.Map<ProductImage>(dtoImg)) // Map DTO -> Entity
            .ToList();

            var remainingImages = existingImages.Except(imagesToDelete).ToList();

            // Sure all images before store is IsMain = FALSE 
            foreach (var img in remainingImages) { img.IsMain = false; }
            foreach (var img in imagesToAdd) 
            { 
                img.IsMain = false; 
                img.ProductId = id; 
            }

            var firstImageDto = newImageDtos.FirstOrDefault();
            if (firstImageDto != null)
            {
                // 5d. Tìm ảnh tương ứng trong DB (có thể là ảnh cũ hoặc ảnh mới)
                var mainImage = remainingImages.FirstOrDefault(i => i.PublicId == firstImageDto.PublicId) // Tìm trong ảnh cũ
                                ?? imagesToAdd.FirstOrDefault(i => i.PublicId == firstImageDto.PublicId); // Tìm trong ảnh mới

                if (mainImage != null)
                {
                    mainImage.IsMain = true; // Đặt làm ảnh chính
                }
            }
            
            _context.ProductImages.RemoveRange(imagesToDelete);
            await _context.ProductImages.AddRangeAsync(imagesToAdd);

            await _context.SaveChangesAsync();

            foreach (var image in imagesToDelete)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(image.PublicId);
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi, nhưng không dừng chương trình
                    // (Ví dụ: file đã bị xóa thủ công trên Cloudinary)
                    Console.WriteLine($"Lỗi khi xóa file {image.PublicId}: {ex.Message}");
                }
            }
        }
    }
}
