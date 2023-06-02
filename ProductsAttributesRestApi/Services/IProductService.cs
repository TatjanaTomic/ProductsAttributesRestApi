using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Services;

public interface IProductService
{
    Task<List<ProductResponse>> GetAllProducts();
    Task<ProductResponse> GetProductById(int id);
    Task<ProductResponse> AddProduct(ProductRequest productRequest);
    Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest);
    Task<bool> DeleteProduct(int id);
    Task<List<ProductResponse>> FilterProducts(ProductFilterRequest filter);
    Task<List<ProductResponse>> FilterProductsByAttribute(AttributeValueFilter filter);
}
