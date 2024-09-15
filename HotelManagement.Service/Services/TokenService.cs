using HotelManagement.Core.Configuration;
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using HotelManagement.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HotelManagement.Service.Services;
public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly CustomTokenOptions _tokenOptions;

    public TokenService(UserManager<AppUser> userManager, IOptions<CustomTokenOptions> customTokenOptions)
    {
        _userManager = userManager;
        _tokenOptions = customTokenOptions.Value;
    }

    private string CreateRefreshToken()
    {
        var numberByte = new Byte[32];

        using var rnd = RandomNumberGenerator.Create();

        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }
    private IEnumerable<Claim> GetClaim(AppUser appUser, List<string> audiences)
    {
        var userList = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, appUser.Id),
            new Claim(JwtRegisteredClaimNames.Email ,appUser.Email),
            new Claim(ClaimTypes.Name, appUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        userList.AddRange(audiences.Select(x=> new Claim(JwtRegisteredClaimNames.Aud, x)));
        return userList;
    }

    private IEnumerable<Claim> GetClaimsByClient(Client client)
    {
        var claims = new List<Claim>();
        claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
        new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString());

        return claims;
    }
    // Generate AccessToken, RefreshToken
    public TokenDto CreateToken(AppUser appUser)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);

        var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaim(appUser, _tokenOptions.Audience),
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();

        var token = handler.WriteToken(jwtSecurityToken);

        var tokenDto = new TokenDto
        {
            AccessToken = token,
            RefreshToken = CreateRefreshToken(),
            AccessTokenExpirationDate = accessTokenExpiration,
            RefreshTokenExpirationDate = refreshTokenExpiration,
        };

        return tokenDto;
    }
  
    public ClientTokenDto CreateTokenByClient(Client client)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaimsByClient(client),
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();

        var token = handler.WriteToken(jwtSecurityToken);

        var clientTokenDto = new ClientTokenDto
        {
            AccessToken = token,
            AccessTokenExpirationDate = accessTokenExpiration,

        };

        return clientTokenDto;
    }
}
 
