using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneMaterialBatchQuery : IRequest<MaterialBatchDto>
    {
        public Guid Id { get; set; }

        public GetOneMaterialBatchQuery(Guid id)
        {
            Id = id;
        }
    }
}
