using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateProjection<Database.Material, Application.Queries.MaterialDto>();
        }
    }
}
