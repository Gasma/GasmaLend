using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Data;
using gasmaTools.Abstraction.Domain.CommandHandlers;
using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Domain.Commands.Login;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Events.Login;
using gasmaTools.Infra.CrossCutting.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaTools.Domain.CommandHandlers
{
    public class LoginCommandHandler : CommandHandler,
        IRequestHandler<InsertLoginCommand, bool>,
        IRequestHandler<SignInLoginCommand, bool>,
        IDisposable
    {
        private readonly IMediatorHandler mediator;
        private UserManager<AppUser> userManager;
        private AppSettings appOpt;

        public LoginCommandHandler(IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> domainNotifications,
            UserManager<AppUser> userManager, IOptions<AppSettings> appOpt) : base(unitOfWork, mediator, domainNotifications)
        {
            this.userManager = userManager;
            this.mediator = mediator;
            this.appOpt = appOpt.Value;
        }

        public Task<bool> Handle(InsertLoginCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var appuser = new AppUser(command.UserName, command.Email, command.FullName);
            var result = userManager.CreateAsync(appuser, command.Password).Result;
            userManager.AddToRoleAsync(appuser, "User");
            if (result.Succeeded)
            {
                mediator.RaiseEventAsync(new InsertLoginEvent(command.Email, command.FullName));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    mediator.RaiseEventAsync(new DomainNotification(command.MessageType, item.Description));
                }
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {

        }

        public Task<bool> Handle(SignInLoginCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var user = userManager.FindByEmailAsync(command.Email).Result;
            if (user != null && userManager.CheckPasswordAsync(user, command.Password).Result)
            {
                var role = userManager.GetRolesAsync(user).Result;
                IdentityOptions identityOptions = new IdentityOptions();
                var tokeDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] { 
                        new Claim(identityOptions.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appOpt.JWT_Secret)), 
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                command.SetToken(tokenHandler.WriteToken(tokenHandler.CreateToken(tokeDescriptor)));
            } 
            else
            {
                mediator.RaiseEventAsync(new DomainNotification(command.MessageType, "Login e/ou senha incorretos"));
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
