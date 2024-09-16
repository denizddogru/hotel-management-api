using AutoMapper;
using HotelManagement.Core.Dtos;
using HotelManagement.Core.Entity;

namespace HotelManagement.Service.Mapper;
public class DtoMapper : Profile
{
    public DtoMapper()
    {
        //  AppUserDto nesnesini Product nesnesine dönüştürmek için harita oluşturulur.

        CreateMap<AppUserDto, AppUser>().ReverseMap();
    }
}
