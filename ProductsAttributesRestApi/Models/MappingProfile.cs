using AutoMapper;
using ProductsAttributesRestApi.Models.Dtos;
using ProductsAttributesRestApi.Models.Entities;

namespace ProductsAttributesRestApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Attribute, AttributeRequest>();
        CreateMap<AttributeRequest, Attribute>();
        CreateMap<Attribute, AttributeResponse>();
        CreateMap<AttributeResponse, Attribute>();
        
        CreateMap<Product, ProductRequest>();
        CreateMap<ProductRequest, Product>();
        CreateMap<ProductResponse, Product>();
        CreateMap<Product, ProductResponse>();

        CreateMap<ProductAttribute, AttributeValue>();
        CreateMap<AttributeValue, ProductAttribute>();
        
        CreateMap<User, UserRequest>();
        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
        CreateMap<UserResponse, User>();
        CreateMap<User, AuthRequest>();
        CreateMap<AuthRequest, User>();
    }
}
