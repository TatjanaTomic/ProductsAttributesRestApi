﻿using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Services;
using ProductsAttributesRestApi.Services.Impl;

namespace ProductsAttributesRestApi.Controllers;

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
    public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProductById(int id)
    {
        var result = await _productService.GetProductById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    public async Task<ActionResult<List<ProductResponse>?>> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}
