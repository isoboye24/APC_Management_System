using FluentValidation;

namespace APCMS.Application.Features.MembershipCategories.Commands.CreateMembershipCategory
{
    public class CreateMembershipCategoryCommandValidator : AbstractValidator<CreateMembershipCategoryCommand>
    {
        public CreateMembershipCategoryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
