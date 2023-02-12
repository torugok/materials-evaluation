using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateProjection<Database.Test, Application.Queries.TestDto>();
        }
    }
}
