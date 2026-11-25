using APCMS.Application.Utilities;

namespace APCMS.Application.Features.MembershipCategories.Commands.CreateMembershipCategory
{
    public class CreateMembershipCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
