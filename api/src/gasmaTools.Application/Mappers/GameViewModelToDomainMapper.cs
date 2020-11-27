using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Game;
using System;

namespace gasmaTools.Application.Mappers
{
    public class GameViewModelToDomainMapper : Profile
    {
        public GameViewModelToDomainMapper()
        {
            CreateMap<GameViewModel, InsertGameCommand>()
                .ConvertUsing(viewModel => new InsertGameCommand(viewModel.Name, viewModel.Description));

            CreateMap<GameViewModel, UpdateGameCommand>()
                .ConstructUsing(viewModel => new UpdateGameCommand(viewModel.Id, viewModel.Name, viewModel.Description));

            CreateMap<GameViewModel, ActivateGameCommand>()
                .ConstructUsing(viewModel => new ActivateGameCommand(viewModel.Id));

            CreateMap<GameViewModel, InactivateGameCommand>()
                .ConstructUsing(viewModel => new InactivateGameCommand(viewModel.Id));            
            
            CreateMap<GameViewModel, GiveBackGameCommand>()
                .ConstructUsing(viewModel => new GiveBackGameCommand(viewModel.Id));            
            
            CreateMap<GameViewModel, LendGameCommand>()
                .ConstructUsing(viewModel => new LendGameCommand(viewModel.Id, viewModel.PersonId));
        }
    }
}
