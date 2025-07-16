using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstraction.Interfaces;
using Services.Specifications;
using Shared;

namespace Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(SpecificationsProductParams specificationsProductParams ,bool asNoTracking = false)
    {
        var products = await unitOfWork.GetRepo<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(specificationsProductParams));
        var mappedProducts = mapper.Map<IEnumerable<ProductResultDto>>(products);
        return mappedProducts;
    }

    public async Task<ProductResultDto?> GetProductByIdAsync(int id)
    {
        var product = await unitOfWork.GetRepo<Product, int>()
            .GetByIdAsync(new ProductWithBrandAndTypeSpecifications(id));
        var mappedProduct = mapper.Map<ProductResultDto?>(product);
        return mappedProduct;
    }

    public async Task<IEnumerable<BrandResultDto>> GetAllProductBrandsAsync()
    {
        var brands = await unitOfWork.GetRepo<ProductBrand, int>().GetAllAsync();
        var mappedBrands = mapper.Map<IEnumerable<BrandResultDto>>(brands);
        return mappedBrands;
    }

    public async Task<IEnumerable<TypeResultDto>> GetAllProductTypeAsync()
    {
        var types = await unitOfWork.GetRepo<ProductType, int>().GetAllAsync();
        var mappedTypes = mapper.Map<IEnumerable<TypeResultDto>>(types);
        return mappedTypes;
    }
}