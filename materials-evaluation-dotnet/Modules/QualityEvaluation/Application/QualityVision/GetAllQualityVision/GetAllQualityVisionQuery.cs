using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllQualityVisionQuery : IRequest<List<QualityVisionDto>> { }
}
