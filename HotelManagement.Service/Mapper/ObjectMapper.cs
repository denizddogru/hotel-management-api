using AutoMapper;

namespace HotelManagement.Service.Mapper;
public static class ObjectMapper
{
    private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(conf =>
        {
            conf.AddProfile<DtoMapper>();
        });

        return config.CreateMapper();
    });

    public static IMapper Mapper => lazy.Value;
}
