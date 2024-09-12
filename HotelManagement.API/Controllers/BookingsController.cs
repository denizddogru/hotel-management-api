using HotelManagement.Core.Dtos;
using HotelManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingsController : CustomBaseController
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto bookingDto)
    {

        return ActionResultInstance(await _bookingService.CreateBookingAsync(bookingDto));

    }
}
