using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityVisionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QualityVisionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/QualityVisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QualityVisionDto>> PostQualityVision(
            CreateQualityVisionCommand command
        )
        {
            var response = _mediator.Send(command);
            Console.Write(response);
            return Ok(response);
        }
    }
}
