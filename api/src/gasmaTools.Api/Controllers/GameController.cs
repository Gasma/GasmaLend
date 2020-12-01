using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Api.Base;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace gasmaTools.Api
{
    [Route("api/game")]
    [ApiController]
    [Authorize]
    public class GameController : ApiController
    {
        public GameController(INotificationHandler<DomainNotification> domainNotification,
            IMediatorHandler mediator)
            : base(domainNotification, mediator)
        { }

        [HttpGet]
        public IActionResult Get([FromServices] IGameService gameService)
        {
            return Result(gameService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IGameService gameService, [FromRoute] Guid id)
        {
            return Result(gameService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromServices] IGameService gameService, [FromBody] GameViewModel game)
        {
            var result = gameService.Insert(game);
            return Result(result);
        }

        [HttpPut]
        public IActionResult Put([FromServices] IGameService gameService, [FromBody] GameViewModel game)
        {
            gameService.Update(game);
            return Result(game);
        }

        [HttpPut("activate/{id}")]
        public IActionResult Activate([FromServices] IGameService gameService, [FromRoute] Guid id)
        {
            gameService.Activate(id);
            return Result();
        }

        [HttpPut("inactivate/{id}")]
        public IActionResult Inactivate([FromServices] IGameService gameService, [FromQuery] Guid id)
        {
            gameService.Inactivate(id);
            return Result();
        }        
        
        [HttpPut("lend/{id}/{personId}")]
        public IActionResult Lend([FromServices] IGameService gameService, [FromQuery] Guid id, [FromQuery] Guid personId)
        {
            gameService.Lend(id, personId);
            return Result();
        }        
        
        [HttpPut("giveback/{id}")]
        public IActionResult GiveBack([FromServices] IGameService gameService, [FromQuery] Guid id)
        {
            gameService.GiveBack(id);
            return Result();
        }
    }
}
