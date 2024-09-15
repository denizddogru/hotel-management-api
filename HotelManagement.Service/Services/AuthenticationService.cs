using HotelManagement.Core.Configuration;
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using HotelManagement.Core.Repositories;
using HotelManagement.Core.Services;
using HotelManagement.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLibrary.Dtos;

namespace HotelManagement.Service.Services;
public class AuthenticationService : IAuthenticationService
{

    private readonly UserManager<AppUser> _userManager;
    private readonly List<Client> _clients;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;
    private readonly ITokenService _tokenService;

    public AuthenticationService(

        IOptions<List<Client>> optionsClient,
        UserManager<AppUser> userManager,
        IUnitOfWork unitOfWork,
        IGenericRepository<UserRefreshToken> userRefreshToken,
        ITokenService tokenService)
    {
        _clients = optionsClient.Value;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _userRefreshTokenService = userRefreshToken;
        _tokenService = tokenService;
    }
    public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
    {
        if (loginDto == null) { throw new ArgumentNullException(nameof(loginDto)); }

        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null) return Response<TokenDto>.Fail("Email or Password is wrong.", 400, true);


        // if Password does not match
        if(!await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Response<TokenDto>.Fail("Email or password is wrong.", 400, true);
        }

        var token = _tokenService.CreateToken(user);

        var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

        if(userRefreshToken == null)
        { 
            await _userRefreshTokenService.AddAsync(new UserRefreshToken {  UserId = user.Id, RefreshToken = token.RefreshToken, ExpirationDate=token.RefreshTokenExpirationDate });
        }
        else
        {
            userRefreshToken.RefreshToken = token.RefreshToken;
            userRefreshToken.ExpirationDate = token.RefreshTokenExpirationDate;
        }

        await _unitOfWork.CommitAsync();

        return Response<TokenDto>.Success(token, 200);
    }

    public Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto loginDto)
    {
        var client = _clients.SingleOrDefault(x => x.Id == loginDto.ClientId && x.Secret == loginDto.ClientSecret);

        if(client == null)
        {
            return Response<ClientTokenDto>.Fail("ClientId or ClientSecret not found", 404, true);
        }

        var token = _tokenService.CreateTokenByClient(client);
        return Response<ClientTokenDto>.Success(200);

    }

    public async Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
    {
        var existingRefreshToken = await _userRefreshTokenService.Where( x=> x.RefreshToken == refreshToken).SingleOrDefaultAsync();

        if(existingRefreshToken == null)
        {
            return Response<TokenDto>.Fail("Refresh Token not found.", 404, true);
        }

        var user = await _userManager.FindByIdAsync(existingRefreshToken.UserId);

        if(user==null)
        {
            return Response<TokenDto>.Fail("User not found.", 404, true);
        }

        var tokenDto = _tokenService.CreateToken(user);

        existingRefreshToken.RefreshToken = tokenDto.RefreshToken;
        existingRefreshToken.ExpirationDate=tokenDto.RefreshTokenExpirationDate;

        await _unitOfWork.CommitAsync();

        return Response<TokenDto>.Success(tokenDto, 200);
            

            


    }

    public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
    {
        var revokeRefreshToken = await _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();

        if(revokeRefreshToken == null)
        {
            return Response<NoDataDto>.Fail("RefreshToken not found.", 404, true);
        }

        _userRefreshTokenService.Remove(revokeRefreshToken);

        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(200);
    }
}
