using AutoMapper;
using SmartTeste.Application.ViewModels;
using SmartTeste.Domain.Models;

namespace SmartTeste.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<People, PeopleViewModel>();
        }
    }
}
