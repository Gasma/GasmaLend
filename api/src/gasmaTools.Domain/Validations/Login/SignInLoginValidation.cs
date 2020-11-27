using gasmaTools.Domain.Commands.Login;

namespace gasmaTools.Domain.Validations.Login
{
    public class SignInLoginValidation : LoginValidation<SignInLoginCommand>
    {
        public SignInLoginValidation()
        {
            ValidatePassLogin();
            ValidateEmail();
        }
    }
}
