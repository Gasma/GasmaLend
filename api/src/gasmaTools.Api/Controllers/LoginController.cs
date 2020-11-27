using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Api.Base;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gasmaTools.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ApiController
    {
        public LoginController(INotificationHandler<DomainNotification> domainNotification,
            IMediatorHandler mediator)
            : base(domainNotification, mediator)
        { }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromServices] ILoginService loginService, [FromBody] LoginViewModel login)
        {
            loginService.Insert(login);
            return Result(login);
        }        
        
        [HttpPost]
        public IActionResult Login([FromServices] ILoginService loginService, [FromBody] LoginViewModel login)
        {
            var token = loginService.Login(login);
            return Result(token);
        }
    }
}
