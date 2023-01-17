using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllMaterialBatchQuery : IRequest<List<MaterialBatchDto>> { }
}
