using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Interfaces;
using Shared;

namespace Presintation;
[ApiController]
[Route("api/[controller]")]

public class ProductController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProducts()
    {
        var products = await serviceManager.ProductService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
    {
        var product = await serviceManager.ProductService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("Brands")]
    public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrands()
    {
        var brands = await serviceManager.ProductService.GetAllProductBrandsAsync();
        return Ok(brands);
    }

    [HttpGet("Types")]
    public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypes()
    {
        var types = await serviceManager.ProductService.GetAllProductTypeAsync();
        return Ok(types);
    }
}