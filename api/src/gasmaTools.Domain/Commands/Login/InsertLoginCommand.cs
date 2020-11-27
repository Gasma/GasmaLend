using gasmaTools.Domain.Validations.Login;

namespace gasmaTools.Domain.Commands.Login
{
    public class InsertLoginCommand : LoginCommand
    {
        public InsertLoginCommand(string email, string password, string fullName, string userName)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertLoginValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
