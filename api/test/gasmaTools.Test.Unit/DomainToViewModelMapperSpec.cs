using AutoMapper;
using FluentAssertions;
using gasmaTools.Application.ViewModels;
using gasmaTools.Domain.Entities;
using gasmaTools.Test.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace gasmaTools.Test.Unit
{
    public class DomainToViewModelMapperSpec
    {
        protected IServiceProvider serviceProvider;
        public DomainToViewModelMapperSpec()
        {
            this.serviceProvider = this.BuilderServiceProvider();
        }

        [Fact]
        public void DeveConverterDominioParaViewModelPrestadorUnidade()
        {
            //Given
            var mapper = this.serviceProvider.GetRequiredService<IMapper>();

            var game = this.GameGenerator();

            //When
            var vm = mapper.Map<GameViewModel>(game);

            //Then            
            mapper.Should().NotBeNull();

            game.Should().NotBeNull();

            vm.Should().NotBeNull();
            vm.Name.Should().Be(game.Name);
            vm.Description.Should().Be(game.Description);
        }


        private Game GameGenerator()
        {
            var game = FixtureCreateObject.EntityGenerator<Game>();

            var novo = new Game(
                game.Id,
                game.Name,
                game.Description
            );

            return novo;
        }

        private IServiceProvider BuilderServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(AutoMapperConfig.Initialize());

            return services.BuildServiceProvider();
        }
    }
}
