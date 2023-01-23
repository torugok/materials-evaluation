using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            CreateProjection<Database.Batch, Application.Queries.BatchDto>()
                .ForCtorParam(
                    nameof(Application.Queries.BatchDto.Status),
                    m => m.MapFrom(x => Enum.Parse<Domain.Status>(x.Status))
                )
                .ForMember(
                    d => d.Status,
                    op => op.MapFrom(o => Enum.Parse<Domain.Status>(o.Status))
                );
        }
    }
}
