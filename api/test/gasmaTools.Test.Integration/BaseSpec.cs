using gasmaTools.Abstraction.Data;
using gasmaTools.Test.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace gasmaTools.Test.Integration
{
    public class BaseSpec
    {
        protected string appsettingsJson = @"Settings\appsettings.json";

        protected IServiceProvider serviceProvider;

        public BaseSpec()
        {
            this.serviceProvider = this.BuildServiceProvider();
        }

        public virtual IServiceProvider BuildServiceProvider()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(this.appsettingsJson, optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddRepository(new ContextOptionsBuilder(configuration.GetSection("ConnectionStrings:DefaultConnection").Value, "MarcaSaude.GestaoRede.Infra.Data.Migrations"));
            services
                .AddLogging()
                .AddBus(configuration)
                .AddDomainServices(configuration)
                .AddBus(configuration)
                .AddCommands(configuration)
                .AddNotifications(configuration)
                .AddAppServices(configuration);
            services.AddSingleton<IHostingEnvironment>(new HostingEnvironment());
            services.AddMediatR(typeof(BaseSpec));
            services.AddSingleton(AutoMapperConfig.Initialize());

            return services.BuildServiceProvider();
        }
    }
}
