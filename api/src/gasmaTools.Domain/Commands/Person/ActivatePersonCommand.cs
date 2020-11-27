using gasmaTools.Domain.Validations.Person;
using System;

namespace gasmaTools.Domain.Commands.Person
{
    public class ActivatePersonCommand : PersonCommand
    {
        public ActivatePersonCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new ActivatePersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
