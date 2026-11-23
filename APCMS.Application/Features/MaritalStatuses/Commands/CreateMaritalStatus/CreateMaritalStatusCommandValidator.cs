using FluentValidation;

namespace APCMS.Application.Features.MaritalStatuses.Commands.CreateMaritalStatus
{
    public class CreateMaritalStatusCommandValidator : AbstractValidator<CreateMaritalStatusCommand>
    {
        public CreateMaritalStatusCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
