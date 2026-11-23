using FluentValidation;

namespace APCMS.Application.Features.Professions.Commands.CreateProfession
{
    public class CreateProfessionCommandValidator : AbstractValidator<CreateProfessionCommand>
    {
        public CreateProfessionCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
