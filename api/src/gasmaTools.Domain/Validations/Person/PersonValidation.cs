using FluentValidation;
using gasmaTools.Domain.Commands.Person;
using System;

namespace gasmaTools.Domain.Validations.Person
{
    public abstract class PersonValidation<TCommand> : AbstractValidator<TCommand>
        where TCommand : PersonCommand
    {
        protected void ValidateId()
        {
            RuleFor(person => person.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(person => person.Name)
                .NotEmpty().WithMessage("O nome da pessoa não pode estar em branco.")
                .Length(2, 100).WithMessage("O nome da pessoa deve conter entre 2 a 100 caracteres.");
        }
    }
}
