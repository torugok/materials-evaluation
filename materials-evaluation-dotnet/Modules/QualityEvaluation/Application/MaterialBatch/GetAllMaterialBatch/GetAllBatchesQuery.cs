using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllBatchesQuery : IRequest<List<BatchDto>> { }
}
