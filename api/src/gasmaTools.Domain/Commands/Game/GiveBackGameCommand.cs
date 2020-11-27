using gasmaTools.Domain.Validations.Game;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class GiveBackGameCommand : GameCommand
    {
        public GiveBackGameCommand(Guid id)
        {
            this.Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new GiveBackGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
