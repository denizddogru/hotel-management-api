 using Microsoft.AspNetCore.Mvc;
using HotelManagement.Core.Services;
using HotelManagement.Core.Dtos;
using HotelManagement.API.Controllers;

[Route("api/[controller][action]")]
[ApiController]
public class HotelsController : CustomBaseController
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _hotelService.GetAllHotelsAsync();
        return ActionResultInstance(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _hotelService.GetHotelByIdAsync(id);
        return ActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HotelCreateDto hotelCreateDto)
    {
        var response = await _hotelService.CreateHotelAsync(hotelCreateDto);

        return ActionResultInstance(response);


    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(HotelUpdateDto hotelUpdateDto)
    {
        var response = await _hotelService.UpdateHotelAsync(hotelUpdateDto);
        return ActionResultInstance(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _hotelService.DeleteHotelAsync(id);
        return ActionResultInstance(response);
    }
}