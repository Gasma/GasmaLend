using FluentAssertions;
using gasmaTools.Domain.Commands.Game;
using System.Linq;
using Xunit;

namespace gasmaTools.Test.Unit
{
    public class UnitGameSpec
    {
        [Fact]
        public void MustGameNameExceedMaxLength()
        {
            //Given
            string name = string.Empty;
            for (int i = 0; i < 102; i++)
            {
                name += "a";
            }

            //When
            var game = new InsertGameCommand(name, "Um jogo muito bom");

            //Then
            game.IsValid().Should().BeFalse();
            Assert.Contains("O nome do jogo deve conter entre 2 a 100 caracteres.", game.ValidationResult.Errors.Select(x => x.ErrorMessage));
        }        
        
        [Fact]
        public void MustGameDescriptionExceedMaxLength()
        {
            //Given
            string description = string.Empty;
            for (int i = 0; i < 256; i++)
            {
                description += "a";
            }

            //When
            var game = new InsertGameCommand("Super Bomberman 4", description);

            //Then
            game.IsValid().Should().BeFalse();
            Assert.Contains("A descrição do jogo deve conter no maximo 255 caracteres.", game.ValidationResult.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void MustBeValidGame()
        {
            //Given
            var game = new InsertGameCommand("Super Bomberman 4", "Joguinho danado de bom.");

            //Then
            game.IsValid().Should().BeTrue();
        }

        [Fact]
        public void MustBeInvalidGameByNameError()
        {
            //Given
            var game = new InsertGameCommand(string.Empty, "Joguinho danado de bom.");

            //Then
            game.IsValid().Should().BeFalse();
        }

        [Fact]
        public void MustBeInvalidGameByDescriptionError()
        {
            //Given
            var game = new InsertGameCommand("Super Bomberman 4", string.Empty);

            //Then
            game.IsValid().Should().BeFalse();
        }
    }
}
