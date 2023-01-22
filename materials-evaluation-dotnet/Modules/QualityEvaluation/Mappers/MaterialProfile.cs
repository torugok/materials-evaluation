using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            // Database to DTOs
            CreateProjection<Database.Material, Application.Queries.MaterialDto>();

            // Database To Domain
            CreateProjection<Database.Material, Domain.Material>();
        }
    }
}
