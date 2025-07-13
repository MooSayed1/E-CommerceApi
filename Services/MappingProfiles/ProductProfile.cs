using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResultDto>().ForMember(dest => dest.BrandName,
                opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name)).ReverseMap();
        CreateMap<BrandResultDto, ProductBrand>();
        CreateMap<TypeResultDto, ProductType>();
    }
}