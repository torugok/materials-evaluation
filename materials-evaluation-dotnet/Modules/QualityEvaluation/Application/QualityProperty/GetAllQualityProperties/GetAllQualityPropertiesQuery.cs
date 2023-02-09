using MediatR;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class GetAllQualityPropertiesQuery : IRequest<List<QualityPropertyDto>> { }
}
