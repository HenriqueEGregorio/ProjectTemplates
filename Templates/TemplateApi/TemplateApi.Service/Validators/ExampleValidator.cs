using FluentValidation;
using TemplateApi.Service.Models.Post.Request;

namespace TemplateApi.Service.Validators
{
    public class ExampleValidator : AbstractValidator<PostExampleEntityRequestModel>
    {
        public ExampleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.")
                .MinimumLength(3).WithMessage("O nome deve ter no mais de 4 caracteres.");

            RuleFor(x => x.Age)
                .NotEqual(0).WithMessage("Idade deve ser informada.");
        }
    }
}
