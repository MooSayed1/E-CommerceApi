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
    
}