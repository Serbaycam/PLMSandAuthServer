using AuthIdentityJWT.Core.Dtos;
using AuthIdentityJWT.SharedLibrary.Dtos;

namespace AuthIdentityJWT.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateToken(SignInDto signInDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDto> CreateTokenByClient(ClientSignInDto clientSignInDto);
    }
}
