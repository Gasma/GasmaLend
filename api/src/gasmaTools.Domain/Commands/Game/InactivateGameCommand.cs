using gasmaTools.Domain.Validations.Game;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class InactivateGameCommand : GameCommand
    {
        public InactivateGameCommand(Guid id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InactivateGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
