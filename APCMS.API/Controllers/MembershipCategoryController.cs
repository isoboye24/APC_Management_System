using APCMS.API.DTOs.MembershipCategories;
using APCMS.Application.Features.MembershipCategories.Commands.CreateMembershipCategory;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/membership-categories")]
    public class MembershipCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMembershipCategoryDTO createMembershipCategoryDTO)
        {
            var command = new CreateMembershipCategoryCommand
            {
                Name = createMembershipCategoryDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
