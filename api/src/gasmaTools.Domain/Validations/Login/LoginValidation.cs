using FluentValidation;
using gasmaTools.Domain.Commands.Login;

namespace gasmaTools.Domain.Validations.Login
{
    public abstract class LoginValidation<TCommand> : AbstractValidator<TCommand>
        where TCommand : LoginCommand
    {
        protected void ValidatePassword()
        {
            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("A senha não pode estar em branco.")
                .Length(8).WithMessage("A senha precisa ter 8 caracteres.");
        }           
        
        protected void ValidatePassLogin()
        {
            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("A senha não pode estar em branco.");
        }        
        
        protected void ValidateFullName()
        {
            RuleFor(login => login.FullName)
                .NotEmpty().WithMessage("O nome completo não pode estar em branco.");
        }

        protected void ValidateEmail()
        {
            RuleFor(login => login.Email)
                .NotEmpty().WithMessage("O email não pode estar em branco.")
                .EmailAddress().WithMessage("O email informado não é valido.");
        }
    }
}
