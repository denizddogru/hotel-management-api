using AutoMapper;
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;

namespace HotelManagement.Service.Mapper;
public class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<AppUserDto, AppUser>().ReverseMap();
    }
}
