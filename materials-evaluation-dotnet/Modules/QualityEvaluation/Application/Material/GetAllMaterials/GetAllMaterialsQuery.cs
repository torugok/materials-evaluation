using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllMaterialsQuery : IRequest<List<MaterialDto>> { }
}
