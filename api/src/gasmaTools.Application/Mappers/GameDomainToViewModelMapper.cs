using AutoMapper;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Game;
using gasmaTools.Domain.Entities;

namespace gasmaTools.Application.Mappers
{
    public class GameDomainToViewModelMapper : Profile
    {
        public GameDomainToViewModelMapper()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<InsertGameCommand, GameViewModel>();
        }
    }
}
