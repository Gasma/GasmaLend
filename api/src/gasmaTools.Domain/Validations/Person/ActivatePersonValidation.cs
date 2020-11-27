using gasmaTools.Domain.Commands.Person;

namespace gasmaTools.Domain.Validations.Person
{
    public class ActivatePersonValidation : PersonValidation<ActivatePersonCommand>
    {
        public ActivatePersonValidation()
        {
            ValidateId();
        }
    }
}
