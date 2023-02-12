using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateProjection<Domain.Material, Application.Queries.MaterialDto>();
        }
    }
}
