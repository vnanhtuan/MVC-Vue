using AutoMapper;
using Core.Application.DTOs;
using Core.Application.DTOs.Category;
using Core.Application.DTOs.Product;
using Core.Domain.Entities;

namespace Core.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Định nghĩa quy tắc: Map từ Product sang ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Images,
                           opt => opt.MapFrom(src => src.ProductImages));

            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.MainImageUrl,
                            opt => opt.MapFrom(src =>
                            src.ProductImages.FirstOrDefault(i => i.IsMain).Url ?? ""))
                .ForMember(dest => dest.CategoryName,
                            opt => opt.MapFrom(src => 
                            src.Category.Name));

            CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.ProductImages,
                       opt => opt.MapFrom(src => src.Images.Select(img => new ProductImage { Url = img.Url, PublicId = img.PublicId, IsMain = false })));

            CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.ProductImages,
                       opt => opt.Ignore()); // không auto map, Vì chúng ta sẽ xử lý map ảnh thủ công để xóa image trên cloudinary

            // Map Category
            CreateMap<Category, CategoryDto>()
                // Tạm thời để Products là null, chúng ta sẽ xử lý sau
                .ForMember(dest => dest.Products, opt => opt.Ignore());
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            // Map ProductImage
            CreateMap<ProductImage, ImageDto>();
            CreateMap<ProductUpdateImage, ProductImage>();
        }
    }
}
