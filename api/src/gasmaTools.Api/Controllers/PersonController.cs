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
    [Route("api/person")]
    [ApiController]
    [Authorize]
    public class PersonController : ApiController
    {
        public PersonController(INotificationHandler<DomainNotification> domainNotification,
             IMediatorHandler mediator)
             : base(domainNotification, mediator)
        { }

        [HttpGet]
        public IActionResult Get([FromServices] IPersonService personService)
        {
            return Result(personService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IPersonService personService, [FromRoute] Guid id)
        {
            return Result(personService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromServices] IPersonService personService, [FromBody] PersonViewModel person)
        {
            var result = personService.Insert(person);
            return Result(result);
        }

        [HttpPut]
        public IActionResult Put([FromServices] IPersonService personService, [FromBody] PersonViewModel person)
        {
            personService.Update(person);
            return Result(person);
        }

        [HttpPut("activate/{id}")]
        public IActionResult Activate([FromServices] IPersonService personService, [FromRoute] Guid id)
        {
            personService.Activate(id);
            return Result();
        }

        [HttpPut("inactivate/{id}")]
        public IActionResult Inactivate([FromServices] IPersonService personService, [FromQuery] Guid id)
        {
            personService.Inactivate(id);
            return Result();
        }
    }
}
