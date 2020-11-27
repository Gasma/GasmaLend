using AutoMapper;
using gasmaTools.Abstraction.Bus;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Person;
using gasmaTools.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gasmaTools.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;
        private readonly IPersonReadRepository personReadRepository;

        public PersonService(
            IMapper mapper,
            IMediatorHandler mediator,
            IPersonReadRepository personReadRepository)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.personReadRepository = personReadRepository;
        }

        public void Activate(Guid id)
        {
            var command = new ActivatePersonCommand(id);
            mediator.SendCommandAsync(command);
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return personReadRepository
                .GetAll()
                .Select(game => mapper.Map<PersonViewModel>(game));
        }

        public PersonViewModel GetById(Guid id)
        {
            return mapper.Map<PersonViewModel>(personReadRepository.GetById(id));
        }

        public void Inactivate(Guid id)
        {
            var command = new InactivatePersonCommand(id);
            mediator.SendCommandAsync(command);
        }

        public void Insert(PersonViewModel gameViewModel)
        {
            var command = mapper.Map<InsertPersonCommand>(gameViewModel);
            mediator.SendCommandAsync(command);
        }

        public void Update(PersonViewModel gameViewModel)
        {
            var command = mapper.Map<UpdatePersonCommand>(gameViewModel);
            mediator.SendCommandAsync(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
