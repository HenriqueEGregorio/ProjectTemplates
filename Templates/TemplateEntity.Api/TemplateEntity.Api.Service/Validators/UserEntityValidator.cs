using FluentValidation;
using TemplateEntity.Api.Domain.Entities;

namespace TemplateEntity.Api.Service.Validators;

public class UserEntityValidator : AbstractValidator<UserEntity>
{
    public UserEntityValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.")
            .MinimumLength(3).WithMessage("O nome deve ter no mais de 4 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email não pode ser nulo ou vazio.");
    }
}
