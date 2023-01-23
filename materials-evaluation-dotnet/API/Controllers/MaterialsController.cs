using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsEvaluation.API_Controllers
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostMaterial(CreateMaterialCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(PostMaterial), new CreatedEntity(response));
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialDto>>> GetMaterial()
        {
            return await _mediator.Send(new GetAllMaterialsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDto>> GetOneMaterial(Guid id)
        {
            return await _mediator.Send(new GetOneMaterialQuery(id));
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> EditMaterial(EditMaterialCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteMaterial(Guid id)
        {
            return await _mediator.Send(new DeleteMaterialCommand(id));
        }
    }
}
