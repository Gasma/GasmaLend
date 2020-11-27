using gasmaTools.Domain.Validations.Login;

namespace gasmaTools.Domain.Commands.Login
{
    public class SignInLoginCommand : LoginCommand
    {
        public SignInLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new SignInLoginValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
