using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Exceptions;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Services;

namespace ProductsAttributesRestApi.Controllers;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ProductResponse>> GetProductById(int id)
    {
        try {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }  
    }

    [HttpPost("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<ProductResponse>>> FilterProducts([FromBody] ProductFilterRequest filter)
    {
        if (filter is null || !ModelState.IsValid)
            return BadRequest();

        var result = await _productService.FilterProducts(filter);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<ProductResponse>>> AddProduct([FromBody] ProductRequest productRequest)
    {
        if (productRequest is null || !ModelState.IsValid)
            return BadRequest();

        var result = await _productService.AddProduct(productRequest);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<ProductResponse>?>> UpdateProduct(int id, [FromBody] ProductRequest product)
    {
        if (product is null || !ModelState.IsValid)
            return BadRequest();

        var result = await _productService.UpdateProduct(id, product);

        if(result is null)
            return NotFound();

        return Ok(result);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);

        return result ? Ok() : NotFound();
    }
}
