using gasmaTools.Domain.EventHandlers;
using gasmaTools.Domain.Events.Game;
using gasmaTools.Domain.Events.Login;
using gasmaTools.Domain.Events.Person;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NotificationExtension
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationHandler<ActivateGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<GiveBackGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<InactivateGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<LendGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<UpdateGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<InsertGameEvent>, GameEventHandler>();
            services.AddScoped<INotificationHandler<ActivatePersonEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<InactivatePersonEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<InsertPersonEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<UpdatePersonEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<InsertLoginEvent>, LoginEventHandler>();

            return services;
        }
    }
}
