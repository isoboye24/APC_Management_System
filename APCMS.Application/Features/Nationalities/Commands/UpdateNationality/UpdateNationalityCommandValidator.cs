using FluentValidation;

namespace APCMS.Application.Features.Nationalities.Commands.UpdateNationality
{
    public class UpdateNationalityCommandValidator : AbstractValidator<UpdateNationalityCommand>
    {
        public UpdateNationalityCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
