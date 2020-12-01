using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Person;
using gasmaTools.Domain.Entities;

namespace gasmaTools.Application.Mappers
{
    public class PersonDomainToViewModelMapper : Profile
    {
        public PersonDomainToViewModelMapper()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<InsertPersonCommand, PersonViewModel>();
        }
    }
}
