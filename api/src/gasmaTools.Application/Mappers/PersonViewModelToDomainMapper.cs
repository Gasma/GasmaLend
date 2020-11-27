using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Person;
using System;

namespace gasmaTools.Application.Mappers
{
    public class PersonViewModelToDomainMapper : Profile
    {
        public PersonViewModelToDomainMapper()
        {
            CreateMap<PersonViewModel, InsertPersonCommand>()
                .ConvertUsing(viewModel => new InsertPersonCommand(viewModel.Name, viewModel.Address, viewModel.Age));

            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConstructUsing(viewModel => new UpdatePersonCommand(viewModel.Id, viewModel.Name, viewModel.Address, viewModel.Age));

            CreateMap<PersonViewModel, ActivatePersonCommand>()
                .ConstructUsing(viewModel => new ActivatePersonCommand(viewModel.Id));

            CreateMap<PersonViewModel, InactivatePersonCommand>()
                .ConstructUsing(viewModel => new InactivatePersonCommand(viewModel.Id));
        }      
    }
}
