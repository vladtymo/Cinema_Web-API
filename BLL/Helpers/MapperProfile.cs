using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Core.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            //...
        }
    }
}
