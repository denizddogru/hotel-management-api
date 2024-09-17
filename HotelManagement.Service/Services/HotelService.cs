// HotelService.cs
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;
using HotelManagement.Core.Repositories;
using HotelManagement.Core.Services;
using HotelManagement.Core.UnitOfWork;
using HotelManagement.Service.Mapper;
using SharedLibrary.Dtos;

namespace HotelManagement.Service.Services;

public class HotelService : IHotelService
{
    private readonly IGenericRepository<Hotel> _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HotelService(IGenericRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
    {
        _hotelRepository = hotelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<HotelDto>> GetHotelByIdAsync(int id)
    {
        var hotel = await _hotelRepository.GetByIdAsync(id);
        if (hotel == null)
        {
            return Response<HotelDto>.Fail("Hotel not found", 404, true);
        }
        return Response<HotelDto>.Success(ObjectMapper.Mapper.Map<HotelDto>(hotel), 200);
    }

    public async Task<Response<List<HotelDto>>> GetAllHotelsAsync()
    {
        var hotels = await _hotelRepository.GetAllAsync();
        var hotelsDto = ObjectMapper.Mapper.Map<List<HotelDto>>(hotels);
        return Response<List<HotelDto>>.Success(hotelsDto, 200);
    }

    public async Task<Response<HotelDto>> CreateHotelAsync(HotelCreateDto hotelCreateDto)
    {
        var hotel = ObjectMapper.Mapper.Map<Hotel>(hotelCreateDto);
        await _hotelRepository.AddAsync(hotel);
        await _unitOfWork.CommitAsync();
        return Response<HotelDto>.Success(ObjectMapper.Mapper.Map<HotelDto>(hotel), 201);
    }

    public async Task<Response<NoDataDto>> UpdateHotelAsync(HotelUpdateDto hotelUpdateDto)
    {
        var existingHotel = await _hotelRepository.GetByIdAsync(hotelUpdateDto.Id);
        if (existingHotel == null)
        {
            return Response<NoDataDto>.Fail("Hotel not found", 404, true);
        }

        ObjectMapper.Mapper.Map(hotelUpdateDto, existingHotel);
        _hotelRepository.Update(existingHotel);
        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(204);
    }

    public async Task<Response<NoDataDto>> DeleteHotelAsync(int id)
    {
        var hotel = await _hotelRepository.GetByIdAsync(id);
        if (hotel == null)
        {
            return Response<NoDataDto>.Fail("Hotel not found", 404, true);
        }

        _hotelRepository.Remove(hotel);
        await _unitOfWork.CommitAsync();

        return Response<NoDataDto>.Success(204);
    }
}