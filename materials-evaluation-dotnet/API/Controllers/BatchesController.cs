using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MaterialsEvaluation.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/material-batches")]
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
            try
            {
                var response = await _mediator.Send(command);
                return CreatedAtAction(nameof(PostBatch), new CreatedEntity(response));
            }
            catch (Exception exception)
            {
                if (exception is DbUpdateException || exception is BusinessException)
                {
                    return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
                }

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BatchDto>>> GetBatch()
        {
            try
            {
                var response = await _mediator.Send(new GetAllBatchesQuery());
                return response;
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDto>> GetOneBatch(Guid id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneBatchQuery(id));
                return response ?? (ActionResult<BatchDto>)NotFound();
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteBatch(Guid id)
        {
            try
            {
                return await _mediator.Send(new DeleteBatchCommand(id));
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpPost("{id}/check-tests")]
        public async Task<ActionResult<Guid>> CheckTests(Guid id)
        {
            try
            {
                var response = await _mediator.Send(new CheckTestsCommand(id));
                return response;
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpPut("{id}/add-test")]
        public async Task<ActionResult<CreatedEntity>> AddTest(AddTestToBatchCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return new CreatedEntity(response);
            }
            catch (Exception exception)
            {
                if (exception is DbUpdateException || exception is BusinessException)
                {
                    return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
                }

                throw;
            }
        }
    }
}
