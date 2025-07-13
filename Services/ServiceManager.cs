using AutoMapper;
using Domain.Contracts;
using Services.Abstraction.Interfaces;

namespace Services;

public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
{
    // defer execution of ProductService creation until it's actually necessary
    private readonly Lazy<IProductService> _productService = new(() => new ProductService(unitOfWork, mapper));
    public IProductService ProductService => _productService.Value;
}