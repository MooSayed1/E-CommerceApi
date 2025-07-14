using Domain.Entities;

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
    
    public ProductWithBrandAndTypeSpecifications(string? sort,int? typeId,int? brandId): base(product=>
        (!brandId.HasValue||product.BrandId==brandId)&&(!typeId.HasValue||product.TypeId==typeId)
        )
    {
        IncludeExpressions.Add(product => product.ProductBrand);
        IncludeExpressions.Add(product => product.ProductType);

        if (sort is not null)
        {
            switch (sort.ToLower().Trim())
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