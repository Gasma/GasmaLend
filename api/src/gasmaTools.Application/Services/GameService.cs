using AutoMapper;
using gasmaTools.Abstraction.Bus;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Game;
using gasmaTools.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gasmaTools.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;
        private readonly IGameReadRepository gameReadRepository;

        public GameService(
            IMapper mapper,
            IMediatorHandler mediator,
            IGameReadRepository gameReadRepository)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.gameReadRepository = gameReadRepository;
        }

        public void Activate(Guid id)
        {
            var command = new ActivateGameCommand(id);
            mediator.SendCommandAsync(command);
        }

        public IEnumerable<GameViewModel> GetAll()
        {
            return gameReadRepository
                .GetGameWithPerson().Result
                .Select(game => mapper.Map<GameViewModel>(game));
        }

        public GameViewModel GetById(Guid id)
        {
            return mapper.Map<GameViewModel>(gameReadRepository.GetById(id));
        }

        public void GiveBack(Guid id)
        {
            var command = new GiveBackGameCommand(id);
            mediator.SendCommandAsync(command);
        }

        public void Inactivate(Guid id)
        {
            var command = new InactivateGameCommand(id);
            mediator.SendCommandAsync(command);
        }

        public void Insert(GameViewModel gameViewModel)
        {
            var command = mapper.Map<InsertGameCommand>(gameViewModel);
            mediator.SendCommandAsync(command);
        }

        public void Lend(Guid id, Guid personId)
        {
            var command = new LendGameCommand(id, personId);
            mediator.SendCommandAsync(command);
        }

        public void Update(GameViewModel gameViewModel)
        {
            var command = mapper.Map<UpdateGameCommand>(gameViewModel);
            mediator.SendCommandAsync(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
