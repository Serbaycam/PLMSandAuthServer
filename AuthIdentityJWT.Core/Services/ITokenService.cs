using AuthIdentityJWT.Core.Configuration;
using AuthIdentityJWT.Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentityJWT.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(IdentityUser user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
