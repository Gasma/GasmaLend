using FluentAssertions;
using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Api;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using gasmaTools.Test.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace gasmaTools.Test.Integration.Controllers
{
    public class GameControllerSpec : BaseSpec
    {
        public GameControllerSpec()
        {

        }

        [Fact(DisplayName = "MustSaveGame should return Ok if everything goes well")]
        public void MustSaveGame()
        {
            //Given
            var domainNotification = serviceProvider.GetService<INotificationHandler<DomainNotification>>();
            var mediator = serviceProvider.GetService<IMediatorHandler>();
            var gameService = serviceProvider.GetService<IGameService>();
            var controller = new GameController(domainNotification, mediator);
            var gameViewModel = FixtureCreateObject.CriarViewModel<GameViewModel>();

            //When
            var result = controller.Post(gameService, gameViewModel);
            var response = GetResponse<GameViewModel>(result);

            //Then
            response.Data.Id.Should().NotBeEmpty();
            response.Data.Id.Should().NotBe(Guid.Empty);
        }        
        
        [Fact(DisplayName = "MustSaveGame should return Ok if everything goes well")]
        public void MustSaveGetUpdateGame()
        {
            //Given
            var domainNotification = serviceProvider.GetService<INotificationHandler<DomainNotification>>();
            var mediator = serviceProvider.GetService<IMediatorHandler>();
            var gameService = serviceProvider.GetService<IGameService>();
            var controller = new GameController(domainNotification, mediator);
            var gameViewModel = FixtureCreateObject.CriarViewModel<GameViewModel>();

            //When
            //Save
            var result = controller.Post(gameService, gameViewModel);
            var response = GetResponse<GameViewModel>(result);
            //Recovery
            var getValue = controller.Get(gameService, response.Data.Id);
            var getResponse = GetResponse<GameViewModel>(getValue);
            //Update and Persist
            var modelUpdate = getResponse.Data;
            modelUpdate.Name = "Novo Nome";
            controller.Put(gameService, modelUpdate);
            //Get updated value
            var getFinal = controller.Get(gameService, response.Data.Id);
            var getResponseFinal = GetResponse<GameViewModel>(getFinal);

            //Then
            getResponseFinal.Data.Name.Should().Be("Novo Nome");
        }
    }
}
