using FluentValidation;

namespace APCMS.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
