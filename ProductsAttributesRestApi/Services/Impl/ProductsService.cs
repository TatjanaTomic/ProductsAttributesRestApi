using AutoMapper;
using ProductsAttributesRestApi.Exceptions;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;
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
        var products = _mapper.Map<List<ProductResponse>>(result);
        foreach(var p  in products)
        {
            p.AttributesValues = _mapper.Map<List<AttributeValue>>(await _productsRepository.GetProductAttributes(p.Id));
        }

        return products;
    }

    public async Task<ProductResponse> GetProductById(int id)
    {
        var product = await _productsRepository.GetProductById(id) ?? throw new NotFoundException();

        var result = _mapper.Map<ProductResponse>(product); 
        result.AttributesValues = _mapper.Map<List<AttributeValue>>(await _productsRepository.GetProductAttributes(result.Id));
        
        return result;
    }

    public async Task<List<ProductResponse>> AddProduct(ProductRequest productRequest)
    {
        var product = _mapper.Map<Product>(productRequest);
        var result = await _productsRepository.AddProduct(product);
        return _mapper.Map<List<ProductResponse>>(result);
    }

    public async Task<List<ProductResponse>?> UpdateProduct(int id, ProductRequest productRequest)
    {
        var product = _mapper.Map<Product>(productRequest);
        product.Id = id;

        var result = await _productsRepository.UpdateProduct(id, product);
        if (result is null)
            return null;

        return _mapper.Map<List<ProductResponse>>(result);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        return await _productsRepository.DeleteProduct(id);
    }

    public async Task<List<ProductResponse>> FilterProducts(ProductFilterRequest filter)
    {
        var result = await _productsRepository.FilterProducts(filter);
        return _mapper.Map<List<ProductResponse>>(result);
    }
}
