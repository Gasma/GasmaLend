using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class ActivateGameCommand : GameCommand
    {
        public ActivateGameCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new ActivateGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
