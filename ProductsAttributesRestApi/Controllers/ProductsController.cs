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
    public async Task<ActionResult<ProductResponse>> GetAttributeById(int id)
    {
        var result = await _productService.GetProductById(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}