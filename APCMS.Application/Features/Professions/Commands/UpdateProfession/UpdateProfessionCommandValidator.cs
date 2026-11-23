using FluentValidation;

namespace APCMS.Application.Features.Professions.Commands.UpdateProfession
{
    public class UpdateProfessionCommandValidator : AbstractValidator<UpdateProfessionCommand>
    {
        public UpdateProfessionCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
