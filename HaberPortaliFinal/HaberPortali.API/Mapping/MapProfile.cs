using AutoMapper;
using HaberPortali.API.Dtos;
using HaberPortali.API.Models;
using HaberPortali.Dtos;
using HaberPortali.Models;

namespace HaberPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
