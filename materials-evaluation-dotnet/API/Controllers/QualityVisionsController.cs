using FluentValidation;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/quality-visions")]
    [ApiController]
    public class QualityVisionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateQualityVisionCommand> _validator;

        public QualityVisionsController(
            IMediator mediator,
            IValidator<CreateQualityVisionCommand> validator
        )
        {
            _mediator = mediator;
            _validator = validator;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> PostQualityVision(CreateQualityVisionCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(new { errors = validationResult.ToDictionary() });
            }

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
