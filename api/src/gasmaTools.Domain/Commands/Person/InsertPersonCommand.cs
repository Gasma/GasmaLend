using gasmaTools.Domain.Validations.Person;
using System;

namespace gasmaTools.Domain.Commands.Person
{
    public class InsertPersonCommand : PersonCommand
    {
        public InsertPersonCommand(string name, string address, int age)
        {
            Name = name;
            Address = address;
            Age = age;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertPersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
