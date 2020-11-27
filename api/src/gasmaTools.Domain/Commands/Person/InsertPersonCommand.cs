using gasmaTools.Domain.Validations.Person;

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

        public override bool IsValid()
        {
            ValidationResult = new InsertPersonValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
