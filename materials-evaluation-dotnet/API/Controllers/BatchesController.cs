using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/batches")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> PostBatch(CreateBatchCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(PostBatch), new CreatedEntity(response));
        }

        [HttpGet]
        public async Task<ActionResult<List<BatchDto>>> GetBatch()
        {
            return await _mediator.Send(new GetAllBatchesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDto>> GetOneBatch(Guid id)
        {
            return await _mediator.Send(new GetOneBatchQuery(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteBatch(Guid id)
        {
            return await _mediator.Send(new DeleteBatchCommand(id));
        }

        [HttpPost("{id}/check-tests")]
        public async Task<ActionResult<Guid>> CheckTests(Guid id)
        {
            return await _mediator.Send(new CheckTestsCommand(id));
        }

        [HttpPut("{id}/add-test")]
        public async Task<ActionResult<CreatedEntity>> AddTest(AddTestToBatchCommand command)
        {
            var response = await _mediator.Send(command);
            return new CreatedEntity(response);
        }
    }
}
