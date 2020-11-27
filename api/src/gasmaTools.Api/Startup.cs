using AutoMapper;
using gasmaTools.Abstraction.Data;
using gasmaTools.Application.ViewModels;
using gasmaTools.Infra.CrossCutting.Ioc.Extensions;
using gasmaTools.Infra.CrossCutting.Shared;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace gasmaTools.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRepository(new ContextOptionsBuilder(this.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, "gasmaTools.Infra.Data.Migrations"));
            services.AddAutoMapper(typeof(GameViewModel));
            services.AddMediatR(typeof(Startup));

            services
                .AddDomainServices(this.Configuration)
                .AddBus(this.Configuration)
                .AddCommands(this.Configuration)
                .AddNotifications(this.Configuration)
                .AddAppServices(this.Configuration)
                .AddIdentityConfig(this.Configuration);

            services.AddCors();
           
            services
                .AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }
            app.UseCors(builder => builder.WithOrigins(Configuration["ApplicationSettings:ClientUrl"].ToString()).AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
