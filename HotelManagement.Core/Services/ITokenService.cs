using HotelManagement.Core.Configuration;
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Services;
using System.IdentityModel.Tokens.Jwt;

namespace HotelManagement.Core.Services;
public interface ITokenService
{
    TokenDto CreateToken(AppUser appUser);

    ClientTokenDto CreateTokenByClient(Client client);


}
