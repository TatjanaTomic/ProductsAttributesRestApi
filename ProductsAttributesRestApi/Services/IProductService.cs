using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Services;

public interface IProductService
{
    Task<List<ProductResponse>> GetAllProducts();
    Task<ProductResponse> GetProductById(int id);
    Task<List<ProductResponse>> AddProduct(ProductRequest productRequest);
    Task<List<ProductResponse>?> UpdateProduct(int id, ProductRequest productRequest);
    Task<List<ProductResponse>?> DeleteProduct(int id);

}
