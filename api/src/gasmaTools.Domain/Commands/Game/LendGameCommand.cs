using gasmaTools.Domain.Validations.Game;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class LendGameCommand : GameCommand
    {
        public LendGameCommand(Guid id, Guid personId)
        {
            Id = id;
            PersonId = personId;
        }
        public override bool IsValid()
        {
            ValidationResult = new LendGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
