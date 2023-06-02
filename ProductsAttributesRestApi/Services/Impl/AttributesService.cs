using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsAttributesRestApi.Exceptions;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;
using ProductsAttributesRestApi.Repositories;
using System.Net.WebSockets;

namespace ProductsAttributesRestApi.Services.Impl;

public class AttributesService : IAttributesService
{
    private static readonly string ALREADY_EXISTS = "Attribute already exists.";

    private readonly IAttributesRepository _attributesRepository;
    private readonly IMapper _mapper;

    public AttributesService(IAttributesRepository attributesRepository, IMapper mapper)
    {
        _attributesRepository = attributesRepository;
        _mapper = mapper;
    }

    public async Task<List<AttributeResponse>> GetAllAttributes()
    {
        return _mapper.Map<List<AttributeResponse>>(await _attributesRepository.GetAllAttributes());
    }

    public async Task<AttributeResponse> GetAttributeById(int id)
    {
        return _mapper.Map<AttributeResponse>(await _attributesRepository.GetAttributeById(id));
    }

    public async Task<AttributeResponse> AddAttribute(AttributeRequest attributeRequest)
    {
        var attribute = _mapper.Map<Attribute>(attributeRequest);
        var result = await _attributesRepository.AddAttribute(attribute);
        return _mapper.Map<AttributeResponse>(result);
    }

    public async Task<List<AttributeResponse>?> UpdateAttribute(int id, AttributeRequest attributeRequest)
    {
        var attribute = _mapper.Map<Attribute>(attributeRequest);
        attribute.Id = id;

        var result = await _attributesRepository.UpdateAttribute(id, attribute);
        if (result is null)
            return null;

        return _mapper.Map<List<AttributeResponse>>(result);
    }

    public async Task<List<AttributeResponse>?> DeleteAttribute(int id)
    {
        var result = await _attributesRepository.DeleteAttribute(id);

        if (result is null)
            return null;

        return _mapper.Map<List<AttributeResponse>>(result);
    }
}
