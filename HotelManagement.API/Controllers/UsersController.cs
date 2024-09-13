using HotelManagement.Core.Dtos;
using HotelManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Exceptions;

namespace HotelManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : CustomBaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        throw new CustomException("An error occurred related to the database.");
    }

    [Authorize]
    [HttpGet]

    public async Task<IActionResult> GetUser()
    {
        return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
    }
}
