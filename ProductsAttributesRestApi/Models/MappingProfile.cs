using AutoMapper;
using ProductsAttributesRestApi.Models.Dtos;

namespace ProductsAttributesRestApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Attribute, AttributeRequest>();
        CreateMap<AttributeRequest, Attribute>();
        CreateMap<Attribute, AttributeResponse>();
        CreateMap<AttributeResponse, Attribute>();
    }
}
