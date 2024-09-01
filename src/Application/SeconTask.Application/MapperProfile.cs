using AutoMapper;
using TestTask.Domain.Entites;
using TestTask.Domain.Responses;

namespace TestTask.Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<WeatherData, WeatherDataResponse>()
            .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.Location.CountryCode))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Location.CityName));
    }
}