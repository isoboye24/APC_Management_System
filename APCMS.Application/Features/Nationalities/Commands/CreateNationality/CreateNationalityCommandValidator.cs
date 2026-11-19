using FluentValidation;

namespace APCMS.Application.Features.Nationalities.Commands.CreateNationality
{
    public class CreateNationalityCommandValidator : AbstractValidator<CreateNationalityCommand>
    {
        public CreateNationalityCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
