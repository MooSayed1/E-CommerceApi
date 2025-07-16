using Domain.Entities;
using Shared;

namespace Services.Specifications;

public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
{
    public ProductWithBrandAndTypeSpecifications(int id) : base(product => product.Id == id)
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);
    }

    public ProductWithBrandAndTypeSpecifications() : base(null)
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);
    }
    
    public ProductWithBrandAndTypeSpecifications(specProductParam specProductParam): base(product=>
        (!specProductParam.BrandId.HasValue||product.BrandId==specProductParam.BrandId)&&(!specProductParam.TypeId.HasValue||product.TypeId==specProductParam.TypeId)
        )
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);

        if (specProductParam.Sort is not null)
        {
            switch (specProductParam.Sort)
            {
                case ProductSortOptions.PriceDesc:
                    SetOrderByDescending(product => product.Price);
                    break;
                case ProductSortOptions.PriceAsc:
                    SetOrderByAscending(product => product.Price);
                    break;
                case ProductSortOptions.NameAsc:
                    SetOrderByAscending(product => product.Name);
                    break;
                default:
                    SetOrderByDescending(product => product.Name);
                    break;
            }
        }
        ApplyPagination(specProductParam.PageIndex, specProductParam.PageSize);
    }
    
}