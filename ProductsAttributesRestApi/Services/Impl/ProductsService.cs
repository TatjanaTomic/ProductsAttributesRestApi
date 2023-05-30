using AutoMapper;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Repositories;

namespace ProductsAttributesRestApi.Services.Impl;

public class ProductsService : IProductService
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public ProductsService(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> GetAllProducts()
    {
        var result = await _productsRepository.GetAllProducts();
        return _mapper.Map<List<ProductResponse>>(result);
    }

    public Task<ProductResponse> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponse>> AddProduct(ProductRequest productRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponse>?> UpdateProduct(int id, ProductRequest productRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponse>?> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

}
