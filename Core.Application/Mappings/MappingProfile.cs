using AutoMapper;
using Core.Application.DTOs;
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

            // Map Category
            CreateMap<Category, CategoryDto>()
                // Tạm thời để Products là null, chúng ta sẽ xử lý sau
                .ForMember(dest => dest.Products, opt => opt.Ignore());

            // Map ProductImage
            CreateMap<ProductImage, ImageDto>();
        }
    }
}
