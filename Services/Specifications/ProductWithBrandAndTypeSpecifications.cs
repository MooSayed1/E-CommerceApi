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
    
    public ProductWithBrandAndTypeSpecifications(SpecificationsParam specificationsParam): base(product=>
        (!specificationsParam.BrandId.HasValue||product.BrandId==specificationsParam.BrandId)&&(!specificationsParam.TypeId.HasValue||product.TypeId==specificationsParam.TypeId)
        )
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);

        if (specificationsParam.Sort is not null)
        {
            switch (specificationsParam.Sort.ToLower().Trim())
            {
                case "pricedesc":
                    SetOrderByDescending(product => product.Price);
                    break;
                case "priceasc":
                    SetOrderByAscending(product => product.Price);
                    break;
                case "nameasc":
                    SetOrderByAscending(product => product.Name);
                    break;
                default:
                    SetOrderByDescending(product => product.Name);
                    break;
            }
        }
        
    }
    
}