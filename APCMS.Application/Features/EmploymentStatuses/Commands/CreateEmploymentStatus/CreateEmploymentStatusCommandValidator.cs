using FluentValidation;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.CreateEmploymentStatus
{
    public class CreateEmploymentStatusCommandValidator : AbstractValidator<CreateEmploymentStatusCommand>
    {
        public CreateEmploymentStatusCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
