using AutoMapper;
using gasmaTools.Abstraction.Bus;
using gasmaTools.Application.Interfaces;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Commands.Login;
using System;

namespace gasmaTools.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;

        public LoginService(
            IMapper mapper,
            IMediatorHandler mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public LoginViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }        
        
        public string Login(LoginViewModel gameViewModel)
        {
            var command = mapper.Map<SignInLoginCommand>(gameViewModel);
            mediator.SendCommandAsync(command);

            return command.Token;
        }

        public void Insert(LoginViewModel gameViewModel)
        {
            var command = mapper.Map<InsertLoginCommand>(gameViewModel);
            mediator.SendCommandAsync(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
