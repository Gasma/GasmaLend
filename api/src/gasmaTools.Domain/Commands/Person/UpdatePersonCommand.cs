using gasmaTools.Domain.Validations.Person;
using System;

namespace gasmaTools.Domain.Commands.Person
{
    public class UpdatePersonCommand : PersonCommand
    {
        public UpdatePersonCommand(Guid id, string name, string address, int age)
        {
            Id = id;
            Name = name;
            Address = address;
            Age = age;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
