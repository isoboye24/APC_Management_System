using APCMS.API.DTOs.Nationalities;
using APCMS.Application.Features.Nationalities.Commands.CreateNationality;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/nationalities")]
    public class NationalityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NationalityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNationalityDTO createNationalityDTO)
        {
            var command = new CreateNationalityCommand
            {
                Name = createNationalityDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
