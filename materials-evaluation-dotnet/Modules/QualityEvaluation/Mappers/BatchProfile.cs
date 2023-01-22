using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            // Database to DTOs
            CreateProjection<Database.Batch, Application.Queries.BatchDto>()
                .ForCtorParam(
                    nameof(Application.Queries.BatchDto.Status),
                    m => m.MapFrom(x => Enum.Parse<Domain.Status>(x.Status))
                )
                .ForMember(
                    d => d.Status,
                    op => op.MapFrom(o => Enum.Parse<Domain.Status>(o.Status))
                );

            // Database To Domain
            CreateProjection<Database.Batch, Domain.Batch>()
                .ForCtorParam(
                    nameof(Domain.Batch.Status),
                    m => m.MapFrom(x => Enum.Parse<Domain.Status>(x.Status))
                )
                .ForMember(
                    d => d.Status,
                    op => op.MapFrom(o => Enum.Parse<Domain.Status>(o.Status))
                );
        }
    }
}
