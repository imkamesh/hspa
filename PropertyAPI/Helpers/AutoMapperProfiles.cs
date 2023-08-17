using AutoMapper;
using PropertyAPI.Dtos;
using PropertyAPI.Models;

namespace PropertyAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap(); //Reverse Map will perform City to CityDto & CityDto to City
        }
    }
}
