using AuthIdentityJWT.Core.Dtos;
using AuthIdentityJWT.SharedLibrary.Dtos;

namespace AuthIdentityJWT.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserDto>> GetUserByEMail(string eMail);
    }
}
