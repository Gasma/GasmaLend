using gasmaTools.Domain.Validations.Game;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class UpdateGameCommand : GameCommand
    {
        public UpdateGameCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
