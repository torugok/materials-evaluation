using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/quality-visions")]
    [ApiController]
    public class QualityVisionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QualityVisionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> PostQualityVision(CreateQualityVisionCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(PostQualityVision), new CreatedEntity(response));
        }

        [HttpGet]
        public async Task<ActionResult<List<QualityVisionDto>>> GetQualityVision()
        {
            return await _mediator.Send(new GetAllQualityVisionQuery());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteQualityVision(Guid id)
        {
            return await _mediator.Send(new DeleteQualityVisionCommand(id));
        }
    }
}
