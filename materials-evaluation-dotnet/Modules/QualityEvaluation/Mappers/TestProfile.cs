using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            // Database to DTOs
            CreateProjection<Database.Test, Application.Queries.TestDto>();

            // Database To Domain
            CreateProjection<Database.Test, Domain.Test>();
        }
    }
}
