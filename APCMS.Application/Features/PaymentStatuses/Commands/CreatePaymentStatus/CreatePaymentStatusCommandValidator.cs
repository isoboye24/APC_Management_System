using FluentValidation;

namespace APCMS.Application.Features.PaymentStatuses.Commands.CreatePaymentStatus
{
    public class CreatePaymentStatusCommandValidator : AbstractValidator<CreatePaymentStatusCommand>
    {
        public CreatePaymentStatusCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
