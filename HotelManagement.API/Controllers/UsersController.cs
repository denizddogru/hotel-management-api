using HotelManagement.Core.Dtos;
using HotelManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
    }

    [Authorize]
    [HttpGet]

    public async Task<IActionResult> GetUser()
    {
        return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
    }
}
