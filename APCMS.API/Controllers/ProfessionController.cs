using APCMS.API.DTOs.Professions;
using APCMS.Application.Features.Professions.Commands.CreateProfession;
using APCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace APCMS.API.Controllers
{
    [ApiController]
    [Route("api/professions")]
    public class ProfessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProfessionDTO createProfessionDTO)
        {
            var command = new CreateProfessionCommand
            {
                Name = createProfessionDTO.Name,
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
