using FluentAssertions;
using gasmaTools.Abstraction.Data;
using gasmaTools.Api.Base;
using gasmaTools.Infra.CrossCutting.Ioc.Extensions;
using gasmaTools.Test.Shared;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

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
                .AddJsonFile(this.appsettingsJson);

            var configuration = builder.Build();
            var teste = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            var services = new ServiceCollection();
            services.AddRepository(new ContextOptionsBuilder(configuration.GetSection("ConnectionStrings:DefaultConnection").Value, "gasmaTools.Infra.Data.Migrations"));
            services
                .AddLogging()
                .AddBus(configuration)
                .AddDomainServices(configuration)
                .AddBus(configuration)
                .AddCommands(configuration)
                .AddNotifications(configuration)
                .AddAppServices(configuration);
            services.AddSingleton<IWebHostEnvironment>(new HostingEnvironment());
            services.AddMediatR(typeof(BaseSpec));
            services.AddSingleton(AutoMapperConfig.Initialize());

            return services.BuildServiceProvider();
        }

        protected Response<TPayload> GetResponse<TPayload>(IActionResult result) where TPayload : class
        {
            var r = result as JsonResult;
            return r.Value as Response<TPayload>;
        }
    }
}
