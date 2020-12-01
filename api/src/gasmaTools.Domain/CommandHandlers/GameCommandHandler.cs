using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Data;
using gasmaTools.Abstraction.Domain.CommandHandlers;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Domain.Commands.Game;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Events.Game;
using gasmaTools.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.CommandHandlers
{
    public class GameCommandHandler : CommandHandler,
        IRequestHandler<ActivateGameCommand, bool>,
        IRequestHandler<GiveBackGameCommand, bool>,
        IRequestHandler<InactivateGameCommand, bool>,
        IRequestHandler<InsertGameCommand, bool>,
        IRequestHandler<LendGameCommand, bool>,
        IRequestHandler<UpdateGameCommand, bool>,
        IDisposable
    {
        private readonly IMediatorHandler mediator;
        private readonly IGameReadRepository gameReadRepository;
        private readonly IGameWriteRepository gameWriteRepository;

        public GameCommandHandler(IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> domainNotifications,
            IGameReadRepository gameReadRepository,
            IGameWriteRepository gameWriteRepository) : base(unitOfWork, mediator, domainNotifications)
        {
            this.gameReadRepository = gameReadRepository;
            this.gameWriteRepository = gameWriteRepository;
            this.mediator = mediator;
        }

        public Task<bool> Handle(InsertGameCommand command, CancellationToken cancellationToken)
        {

            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = new Game(command.Name, command.Description);

            gameWriteRepository.Insert(game);

            if (Commit())
            {
                command.SetId(game.Id);
                mediator.RaiseEventAsync(new InsertGameEvent(game.Name, game.Description));
            }

            return Task.FromResult(true);
        }
        
        public Task<bool> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = new Game(command.Id, command.Name, command.Description);

            var gameCadastrado = gameReadRepository.GetByIdAsync(game.Id).Result;
            if (gameCadastrado != null)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "Essa jogo já está cadastrado na base de dados!"));
                return Task.FromResult(false);
            }

            gameWriteRepository.Update(game);

            if (Commit())
            {
                mediator.RaiseEventAsync(new UpdateGameEvent(game.Id, game.Name, game.Description));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ActivateGameCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = gameReadRepository.GetById(command.Id);
            if (game.Active)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "O jogo já está ativo!"));
                return Task.FromResult(false);
            }

            game.Activate();

            gameWriteRepository.Update(game);

            if (Commit())
            {
                mediator.RaiseEventAsync(new ActivateGameEvent(game.Id));
            }

            return Task.FromResult(true);
        }      
        
        public Task<bool> Handle(GiveBackGameCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = gameReadRepository.GetById(command.Id);
            if (!game.PersonId.HasValue)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "O jogo não esta emprestado!"));
                return Task.FromResult(false);
            }

            game.GiveBack();

            gameWriteRepository.Update(game);

            if (Commit())
            {
                mediator.RaiseEventAsync(new GiveBackGameEvent(game.Id));
            }

            return Task.FromResult(true);
        }       
        
        public Task<bool> Handle(LendGameCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = gameReadRepository.GetById(command.Id);

            game.Lend(command.PersonId.Value);

            gameWriteRepository.Update(game);

            if (Commit())
            {
                mediator.RaiseEventAsync(new LendGameEvent(game.Id, game.PersonId.Value));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(InactivateGameCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var game = gameReadRepository.GetById(command.Id);
            if (!game.Active)
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "O jogo já esta inativo!"));
                return Task.FromResult(false);
            }

            game.InActivate();

            gameWriteRepository.Update(game);

            if (Commit())
            {
                mediator.RaiseEventAsync(new InactivateGameEvent(game.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            gameReadRepository.Dispose();
            gameWriteRepository.Dispose();
        }
    }
}
