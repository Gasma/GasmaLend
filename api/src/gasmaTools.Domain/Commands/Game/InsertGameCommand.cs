using gasmaTools.Domain.Validations.Game;
using System;

namespace gasmaTools.Domain.Commands.Game
{
    public class InsertGameCommand : GameCommand
    {
        public InsertGameCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
