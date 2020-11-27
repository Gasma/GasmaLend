using gasmaTools.Application.Interfaces;
using gasmaTools.Application.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}
