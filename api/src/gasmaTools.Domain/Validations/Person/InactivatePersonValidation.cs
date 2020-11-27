using gasmaTools.Domain.Commands.Person;

namespace gasmaTools.Domain.Validations.Person
{
    public class InactivatePersonValidation : PersonValidation<InactivatePersonCommand>
    {
        public InactivatePersonValidation()
        {
            ValidateId();
        }
    }
}
