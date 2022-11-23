using AutoMapper;
using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.Configuration
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDtoCreation, Category>();

            CreateMap<Thing, ThingDto>();
            CreateMap<ThingDtoCreation, Thing>();


        }
    }
}
