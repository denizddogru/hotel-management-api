using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using HotelManagement.Core.Services;
using SharedLibrary.Dtos;

namespace HotelManagement.Service.Services;
public class BookingService : IBookingService
{
    public Task CancelBookingAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Booking>> CreateBookingAsync(BookingCreateDto bookingDto)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> GetBookingByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Booking> UpdateBookingAsync(int id, BookingUpdateDto bookingDto)
    {
        throw new NotImplementedException();
    }
}
