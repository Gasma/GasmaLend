using gasmaTools.Domain.Validations.Game;

namespace gasmaTools.Domain.Commands.Game
{
    public class InsertGameCommand : GameCommand
    {
        public InsertGameCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertGameValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
