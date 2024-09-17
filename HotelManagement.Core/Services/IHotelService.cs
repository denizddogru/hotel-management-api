using HotelManagement.Core.Dtos;
using SharedLibrary.Dtos;

namespace HotelManagement.Core.Services;
public interface IHotelService
{
    Task<Response<HotelDto>> GetHotelByIdAsync(int id);
    Task<Response<List<HotelDto>>> GetAllHotelsAsync();
    Task<Response<HotelDto>> CreateHotelAsync(HotelCreateDto hotelCreateDto);
    Task<Response<NoDataDto>> UpdateHotelAsync(HotelUpdateDto hotelUpdateDto);
    Task<Response<NoDataDto>> DeleteHotelAsync(int id);
}
