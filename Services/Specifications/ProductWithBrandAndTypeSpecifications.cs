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
    
    public ProductWithBrandAndTypeSpecifications(SpecificationsProductParams specificationsProductParams): base(product=>
        (!specificationsProductParams.BrandId.HasValue||product.BrandId==specificationsProductParams.BrandId)&&(!specificationsProductParams.TypeId.HasValue||product.TypeId==specificationsProductParams.TypeId)
        )
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);

        if (specificationsProductParams.Sort is not null)
        {
            switch (specificationsProductParams.Sort)
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
        
    }
    
}