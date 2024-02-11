using AuthIdentity.Core.DTOs;
using AuthIdentity.Core.Entities;
using AutoMapper;

namespace AuthIdentity.Service.Mapping
{
    public class AuthIdentityMapProfile : Profile
    {
        public AuthIdentityMapProfile()
        {
            CreateMap<AuthIdentityUser, AuthIdentityUserLoginDto>().ReverseMap();
            CreateMap<AuthIdentityUser, AuthIdentityUserRegisterDto>().ReverseMap();
            CreateMap<AuthIdentityUser, AuthIdentityUserDto>().ReverseMap();
            CreateMap<AuthIdentityUser, AuthIdentityUserForAdminDto>().ReverseMap();
            CreateMap<AuthIdentityRole, AuthIdentityRoleDto>().ReverseMap();
        }
    }
}
