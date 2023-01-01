using AutoMapper;
using SmartTeste.Application.ViewModels;
using SmartTeste.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTeste.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PeopleViewModel, RegisterNewPeopleCommand>()
                .ConstructUsing(c => new RegisterNewPeopleCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<PeopleViewModel, UpdatePeopleCommand>()
                .ConstructUsing(c => new UpdatePeopleCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
