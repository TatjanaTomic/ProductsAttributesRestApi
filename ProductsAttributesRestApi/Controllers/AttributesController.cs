﻿using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Services;

namespace ProductsAttributesRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributesController : ControllerBase
{
    private readonly IAttributesService _attributeService;

    public AttributesController(IAttributesService attributeService)
    {
        _attributeService = attributeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AttributeResponse>>> GetAllAttributes()
    {
        var result = await _attributeService.GetAllAttributes();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AttributeResponse>> GetAttributeById(int id)
    {
        var result = await _attributeService.GetAttributeById(id);
        
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<AttributeResponse>>> AddAttribute([FromBody] AttributeRequest attributeRequest)
    {
        if (attributeRequest is null || !ModelState.IsValid)
            return BadRequest();

        var result = await _attributeService.AddAttribute(attributeRequest);
        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<AttributeResponse>?>> UpdateAttribute(int id, [FromBody] AttributeRequest attributeRequest)
    {
        if (attributeRequest is null || !ModelState.IsValid)
            return BadRequest();

        var result = await _attributeService.UpdateAttribute(id, attributeRequest);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<AttributeResponse>?>> DeleteAttribute(int id)
    {
        var result = await _attributeService.DeleteAttribute(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}
