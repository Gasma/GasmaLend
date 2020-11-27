using gasmaTools.Abstraction.Data;
using gasmaTools.Domain.Entities;
using gasmaTools.Domain.Repositories;
using gasmaTools.Infra.Data;
using gasmaTools.Infra.Data.Context;
using gasmaTools.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace gasmaTools.Infra.CrossCutting.Ioc.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IContextOptionsBuilder options)
        {
            services.AddDbContextPool<GasmaToolsContext>(options.Builder());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGameReadRepository, GameReadRepository>();
            services.AddScoped<IGameWriteRepository, GameWriteRepository>();

            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();

            return services;
        }
    }
}
