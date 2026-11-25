using APCMS.Application.Contracts.Persistence;
using APCMS.Application.Contracts.Repositories;
using APCMS.Application.Exceptions;
using APCMS.Application.Utilities;
using APCMS.Domain.Entities;

namespace APCMS.Application.Features.MembershipCategories.Commands.CreateMembershipCategory
{
    public class CreateMembershipCategoryCommandHandler : IRequestHandler<CreateMembershipCategoryCommand, Guid>
    {
        private readonly IMembershipCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMembershipCategoryCommandHandler(IMembershipCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMembershipCategoryCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The membership category already exists.");
            }
            else
            {
                var membershipCategory = new MembershipCategory(request.Name);

                try
                {
                    var result = await _repository.Add(membershipCategory);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
