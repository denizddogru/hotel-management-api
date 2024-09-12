using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using SharedLibrary.Dtos;

namespace HotelManagement.Core.Services;
public interface IBookingService
{
    Task<Response<Booking>> CreateBookingAsync(CreateBookingDto bookingDto);
    Task<Booking> GetBookingByIdAsync(int id);
    Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
    Task<Booking> UpdateBookingAsync(int id, UpdateBookingDto bookingDto);
    Task CancelBookingAsync(int id);
}
