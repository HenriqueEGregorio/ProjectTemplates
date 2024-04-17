using FluentValidation;
using TemplateApi.Domain.Entities;

namespace TemplateApi.Service.Validators
{
    public class ExampleValidator : AbstractValidator<ExampleEntity>
    {
        public ExampleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.")
                .MinimumLength(3).WithMessage("O nome deve ter no mais de 4 caracteres.");

            RuleFor(x => x.Age)
                .NotEqual(0).WithMessage("Idade deve ser informada.");
        }

        public void Teste()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.")
                .MinimumLength(3).WithMessage("O nome deve ter no mais de 4 caracteres.");

            RuleFor(x => x.Age)
                .NotEqual(0).WithMessage("Idade deve ser informada.");
        }
    }
}
