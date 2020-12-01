using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Data;
using gasmaTools.Abstraction.Domain.CommandHandlers;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Domain.Commands.Person;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Events.Person;
using gasmaTools.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.CommandHandlers
{
    public class PersonCommandHandler : CommandHandler,
        IRequestHandler<ActivatePersonCommand, bool>,
        IRequestHandler<InactivatePersonCommand, bool>,
        IRequestHandler<InsertPersonCommand, bool>,
        IRequestHandler<UpdatePersonCommand, bool>,
        IDisposable
    {
        private readonly IMediatorHandler mediator;
        private readonly IPersonReadRepository personReadRepository;
        private readonly IPersonWriteRepository personWriteRepository;

        public PersonCommandHandler(IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> domainNotifications,
            IPersonReadRepository personReadRepository,
            IPersonWriteRepository personWriteRepository) : base (unitOfWork, mediator, domainNotifications)
        {
            this.personReadRepository = personReadRepository;
            this.personWriteRepository = personWriteRepository;
            this.mediator = mediator;
        }

        public Task<bool> Handle(InsertPersonCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var person = new Person(command.Name, command.Address, command.Age);

            personWriteRepository.Insert(person);

            if (Commit())
            {
                command.SetId(person.Id);
                mediator.RaiseEventAsync(new InsertPersonEvent(person.Id, person.Name, person.Address, person.Age));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var person = new Person(command.Id, command.Name, command.Address, command.Age);

            //Validação person cadastrado
            var personCadastrado = personReadRepository.GetByIdAsync(person.Id).Result;
            if (personCadastrado != null)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "Essa pessoa já está cadastrado na base de dados!"));
                return Task.FromResult(false);
            }

            personWriteRepository.Update(person);

            if (Commit())
            {
                mediator.RaiseEventAsync(new UpdatePersonEvent(person.Id, person.Name, person.Address, person.Age));
            }

            return Task.FromResult(true);
        }
        
        public Task<bool> Handle(ActivatePersonCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }


            var person = personReadRepository.GetById(command.Id);
            if (person.Active)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "A pessoa já está ativa!"));
                return Task.FromResult(false);
            }

            person.Activate();

            personWriteRepository.Update(person);

            if (Commit())
            {
                mediator.RaiseEventAsync(new ActivatePersonEvent(person.Id));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(InactivatePersonCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var person = personReadRepository.GetById(command.Id);
            if (!person.Active)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "A pessoa ja esta inativa!"));
                return Task.FromResult(false);
            }

            person.InActivate();

            personWriteRepository.Update(person);

            if (Commit())
            {
                mediator.RaiseEventAsync(new InactivatePersonEvent(person.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            personReadRepository.Dispose();
            personWriteRepository.Dispose();
        }
    }
}
