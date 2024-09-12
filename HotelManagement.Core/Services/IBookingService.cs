using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using SharedLibrary.Dtos;

namespace HotelManagement.Core.Services;
public interface IBookingService
{
    Task<Response<Booking>> CreateBookingAsync(BookingCreateDto bookingDto);
    Task<Booking> GetBookingByIdAsync(int id);
    Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
    Task<Booking> UpdateBookingAsync(int id, BookingUpdateDto bookingDto);
    Task CancelBookingAsync(int id);
}
