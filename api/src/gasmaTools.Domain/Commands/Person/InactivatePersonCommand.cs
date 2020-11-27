using gasmaTools.Domain.Validations.Person;
using System;

namespace gasmaTools.Domain.Commands.Person
{
    public class InactivatePersonCommand : PersonCommand
    {
        public InactivatePersonCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InactivatePersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
