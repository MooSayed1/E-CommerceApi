using Shared;

namespace Services.Abstraction.Interfaces;

public interface IProductService
{
    Task <IEnumerable<ProductResultDto>> GetAllProductsAsync(SpecificationsParam specificationsParam ,bool asNoTracking = false);
    Task<ProductResultDto?> GetProductByIdAsync(int id);
    Task<IEnumerable<BrandResultDto>> GetAllProductBrandsAsync();
    Task<IEnumerable<TypeResultDto>> GetAllProductTypeAsync();
}