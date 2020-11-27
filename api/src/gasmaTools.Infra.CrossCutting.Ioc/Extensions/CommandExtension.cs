using gasmaTools.Domain.CommandHandlers;
using gasmaTools.Domain.Commands.Game;
using gasmaTools.Domain.Commands.Login;
using gasmaTools.Domain.Commands.Person;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommandExtension
    {
        public static IServiceCollection AddCommands(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestHandler<ActivateGameCommand, bool>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<GiveBackGameCommand, bool>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<InactivateGameCommand, bool>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<InsertGameCommand, bool>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<LendGameCommand, bool>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGameCommand, bool>, GameCommandHandler>();            
            services.AddScoped<IRequestHandler<ActivatePersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<InactivatePersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<InsertPersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand, bool>, PersonCommandHandler>();            
            services.AddScoped<IRequestHandler<InsertLoginCommand, bool>, LoginCommandHandler>();
            services.AddScoped<IRequestHandler<SignInLoginCommand, bool>, LoginCommandHandler>();

            return services;
        }
    }
}