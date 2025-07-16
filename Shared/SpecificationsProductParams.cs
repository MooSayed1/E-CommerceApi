namespace Shared;

public class SpecificationsProductParams
{
    public ProductSortOptions? Sort { get; set; }
    public int? TypeId { get; set; }
    public int? BrandId { get; set; }
}

public enum ProductSortOptions
{
    NameAsc,
    NameDesc,
    PriceAsc,
    PriceDesc
}