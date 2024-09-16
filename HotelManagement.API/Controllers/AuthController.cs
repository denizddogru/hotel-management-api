using HotelManagement.Core.Dtos;
using HotelManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : CustomBaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateToken(LoginDto loginDto)
    {
        var result = await _authenticationService.CreateTokenAsync(loginDto);

        return ActionResultInstance(result);
    }

    [HttpPost]

    public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
    {
        var result = _authenticationService.CreateTokenByClient(clientLoginDto);
        return ActionResultInstance(result);
    }

    [HttpPost]
    public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
    {
        var result = await _authenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);

        return ActionResultInstance(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
    {
        var result = await _authenticationService.CreateTokenByRefreshTokenAsync(refreshTokenDto.RefreshToken);
        return ActionResultInstance(result);
    }
}
