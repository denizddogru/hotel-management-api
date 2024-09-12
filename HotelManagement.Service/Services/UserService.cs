using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using HotelManagement.Core.Services;
using HotelManagement.Service.Mapper;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;


public class UserService : IUserService
{

    private readonly UserManager<AppUser> _userManager;


    public UserService(UserManager<AppUser> guest)
    {
        _userManager = guest;
    }

    public async Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto userDto)
    {
        var user = new AppUser { Email = userDto.Email, UserName = userDto.UserName };

        var result = await _userManager.CreateAsync(user, userDto.UserName);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();

            return Response<AppUserDto>.Fail(new ErrorDto(errors, true), 400);
        }

        // User will be mapped to AppUserDto, which means that user object will be converted into an object with
        // properties of AppUserDto

        // Why do we map? Simply because we would like to return the values of our dto rather than the whole
        // user object which calls from he library UserManager

        return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);

    }

    public async Task<Response<AppUserDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return Response<AppUserDto>.Fail("Username not found.", 404, true);
        }

        return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
    }

}

