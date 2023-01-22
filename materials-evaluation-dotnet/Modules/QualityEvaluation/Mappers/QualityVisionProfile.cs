using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class QualityVisionProfile : Profile
    {
        public QualityVisionProfile()
        {
            // Database to DTOs
            CreateProjection<Database.QualityVision, Application.Queries.QualityVisionDto>()
                .ForMember(
                    d => d.AvaliationMethodology,
                    op =>
                        op.MapFrom(
                            o =>
                                new Domain.AvaliationMethodology(
                                    o.AvaliationMinQuantity,
                                    Enum.Parse<Domain.Grouping>(o.AvaliationGrouping),
                                    Enum.Parse<Domain.CalculationType>(o.AvaliationCalculationType)
                                )
                        )
                );

            // Database To Domain
            CreateProjection<Database.QualityVision, Domain.QualityVision>()
                .ForMember(
                    d => d.AvaliationMethodology,
                    op =>
                        op.MapFrom(
                            o =>
                                new Domain.AvaliationMethodology(
                                    o.AvaliationMinQuantity,
                                    Enum.Parse<Domain.Grouping>(o.AvaliationGrouping),
                                    Enum.Parse<Domain.CalculationType>(o.AvaliationCalculationType)
                                )
                        )
                );
        }
    }
}
