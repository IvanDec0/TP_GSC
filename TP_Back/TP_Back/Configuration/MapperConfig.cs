using AutoMapper;
using TP_Back.Dto;
using TP_Back.Entities;
using TP_Back.Protos;

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

            CreateMap<NewLoanRequest, LoanDtoCreation>();

            CreateMap<LoansClosedResponse, LoanDto>();
            
            CreateMap<Loan, LoanDto>();
        }
    }
}
