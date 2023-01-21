using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetOneBatchQuery : IRequest<BatchDto?>
    {
        public Guid Id { get; set; }

        public GetOneBatchQuery(Guid id)
        {
            Id = id;
        }
    }
}
