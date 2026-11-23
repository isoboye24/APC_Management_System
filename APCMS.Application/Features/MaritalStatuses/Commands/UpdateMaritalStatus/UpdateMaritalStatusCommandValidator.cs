using FluentValidation;

namespace APCMS.Application.Features.MaritalStatuses.Commands.UpdateMaritalStatus
{
    public class UpdateMaritalStatusCommandValidator : AbstractValidator<UpdateMaritalStatusCommand>
    {
        public UpdateMaritalStatusCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
