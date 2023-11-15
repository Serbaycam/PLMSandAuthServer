using AuthIdentityJWT.Core.Dtos;
using AuthIdentityJWT.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentityJWT.Service.Mapper
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserDto, IdentityUser>().ReverseMap();
        }
    }
}
