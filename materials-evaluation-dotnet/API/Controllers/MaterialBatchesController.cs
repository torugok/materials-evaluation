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
    public class MaterialBatchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialBatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guid>> PostMaterialBatch(CreateMaterialBatchCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return CreatedAtAction(nameof(PostMaterialBatch), new CreatedEntity(response));
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
        public async Task<ActionResult<List<MaterialBatchDto>>> GetMaterialBatch()
        {
            try
            {
                var response = await _mediator.Send(new GetAllMaterialBatchQuery());
                return response;
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialBatchDto>> GetOneMaterialBatch(Guid id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneMaterialBatchQuery(id));
                return response;
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(exception.ToString()); // FIXME: melhorar tratamento de erros de banco
            }
        }

        [HttpPut("{id}/add-test")]
        public async Task<ActionResult<CreatedEntity>> AddTest(
            AddTestToMaterialBatchCommand command
        )
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
