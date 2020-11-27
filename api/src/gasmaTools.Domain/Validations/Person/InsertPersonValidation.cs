using gasmaTools.Domain.Commands.Person;

namespace gasmaTools.Domain.Validations.Person
{
    public class InsertPersonValidation : PersonValidation<InsertPersonCommand>
    {
        public InsertPersonValidation()
        {
            ValidateName();
        }
    }
}
