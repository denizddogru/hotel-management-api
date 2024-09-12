using HotelManagement.Core.Dtos;
using SharedLibrary.Dtos;

namespace HotelManagement.Core.Services;

public interface IUserService
{
    Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto userDto);
    Task<Response<AppUserDto>> GetUserByNameAsync(string userName);

}

