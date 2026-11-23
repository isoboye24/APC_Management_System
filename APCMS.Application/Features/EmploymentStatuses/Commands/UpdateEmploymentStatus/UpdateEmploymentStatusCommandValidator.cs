using FluentValidation;

namespace APCMS.Application.Features.EmploymentStatuses.Commands.UpdateEmploymentStatus
{
    public class UpdateEmploymentStatusCommandValidator : AbstractValidator<UpdateEmploymentStatusCommand>
    {
        public UpdateEmploymentStatusCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
