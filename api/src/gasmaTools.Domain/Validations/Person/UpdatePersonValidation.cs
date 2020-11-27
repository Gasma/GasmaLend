using gasmaTools.Domain.Commands.Person;

namespace gasmaTools.Domain.Validations.Person
{
    public class UpdatePersonValidation : PersonValidation<UpdatePersonCommand>
    {
        public UpdatePersonValidation()
        {
            ValidateName();
        }
    }
}
