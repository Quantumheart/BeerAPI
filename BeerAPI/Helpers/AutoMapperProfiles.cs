using AutoMapper;
using BeerAPI.Models;

namespace BeerAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Beer, DtoBeer>();
            CreateMap<Beer, DtoBeer>().ReverseMap();
        }
    }
}