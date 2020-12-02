using FluentValidation;
using gasmaTools.Domain.Commands.Game;
using System;

namespace gasmaTools.Domain.Validations.Game
{
    public abstract class GameValidation<TCommand> : AbstractValidator<TCommand>
        where TCommand : GameCommand
    {
        protected void ValidateId()
        {
            RuleFor(game => game.Id)
                .NotEqual(Guid.Empty);
        }        
        
        protected void ValidatePersonId()
        {
            RuleFor(game => game.PersonId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(game => game.Name)
                .NotEmpty().WithMessage("O nome do jogo não pode estar em branco.")
                .Length(2, 100).WithMessage("O nome do jogo deve conter entre 2 a 100 caracteres.");
        }        
        
        protected void ValidateDescription()
        {
            RuleFor(game => game.Description)
                .NotEmpty().WithMessage("A descrição do jogo não pode estar em branco.")
                .Length(0, 255).WithMessage("A descrição do jogo deve conter no maximo 255 caracteres.");
        }
    }
}
