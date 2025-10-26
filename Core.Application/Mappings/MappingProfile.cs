using AutoMapper;
using Core.Application.DTOs;
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
                            src.ProductImages.FirstOrDefault(i => i.IsMain).Url ?? ""));

            CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.ProductImages,
                       opt => opt.MapFrom(src => src.ImageUrls.Select(url => new ProductImage { Url = url, IsMain = false })));

            CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.ProductImages,
                       opt => opt.MapFrom(src => src.ImageUrls.Select(url => new ProductImage { Url = url, IsMain = false })));

            // Map Category
            CreateMap<Category, CategoryDto>()
                // Tạm thời để Products là null, chúng ta sẽ xử lý sau
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            // Map ProductImage
            CreateMap<ProductImage, ImageDto>();
        }
    }
}
