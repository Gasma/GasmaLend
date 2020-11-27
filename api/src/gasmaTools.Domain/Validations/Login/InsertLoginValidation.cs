using gasmaTools.Domain.Commands.Login;

namespace gasmaTools.Domain.Validations.Login
{
    public class InsertLoginValidation : LoginValidation<InsertLoginCommand>
    {
        public InsertLoginValidation()
        {
            ValidatePassword();
            ValidateFullName();
            ValidateEmail();
        }
    }
}
