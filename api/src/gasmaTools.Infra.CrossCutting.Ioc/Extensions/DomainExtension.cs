using gasmaTools.Abstraction.Domain.Notifications;
using gasmaTools.Abstraction.Events;
using gasmaTools.Infra.CrossCutting.Logger;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Domain BUS
            services.AddBus(configuration);

            //Domain Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Domain EventSourcing
            services.AddScoped<IEventStore, InConsoleEventStore>();

            return services;
        }
    }
}
