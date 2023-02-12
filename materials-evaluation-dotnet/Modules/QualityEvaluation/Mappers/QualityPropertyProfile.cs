using AutoMapper;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Mappers
{
    public class QualityPropertyProfile : Profile
    {
        public QualityPropertyProfile()
        {
            // Database to DTOs
            CreateProjection<Database.QualityProperty, Application.Queries.QualityPropertyDto>()
                .ForMember(
                    d => d.Type,
                    op => op.MapFrom(o => Enum.Parse<Domain.PropertyTypes>(o.Type))
                )
                .ForMember(
                    d => d.QuantitativeParams,
                    op =>
                        op.MapFrom(
                            o =>
                                new Domain.QuantitativeParams(
                                    o.QuantitativeDecimals.GetValueOrDefault(),
                                    o.QuantitativeUnit ?? string.Empty,
                                    o.QuantitativeNominalValue.GetValueOrDefault(),
                                    o.QuantitativeInferiorLimit.GetValueOrDefault(),
                                    o.QuantitativeSuperiorLimit.GetValueOrDefault()
                                )
                        )
                );

            CreateProjection<
                Database.QualityVisionProperties,
                Application.Queries.QualityPropertyDto
            >()
                .ForMember(
                    d => d.QuantitativeParams,
                    op =>
                        op.MapFrom(
                            o =>
                                new Domain.QuantitativeParams(
                                    o.QualityProperty.QuantitativeDecimals.GetValueOrDefault(),
                                    o.QualityProperty.QuantitativeUnit ?? string.Empty,
                                    o.QualityProperty.QuantitativeNominalValue.GetValueOrDefault(),
                                    o.QualityProperty.QuantitativeInferiorLimit.GetValueOrDefault(),
                                    o.QualityProperty.QuantitativeSuperiorLimit.GetValueOrDefault()
                                )
                        )
                )
                .ForMember(d => d.Acronym, op => op.MapFrom(o => o.QualityProperty.Acronym))
                .ForMember(d => d.Description, op => op.MapFrom(o => o.QualityProperty.Description))
                .ForMember(
                    d => d.Type,
                    op => op.MapFrom(o => Enum.Parse<Domain.PropertyTypes>(o.QualityProperty.Type))
                )
                .ForMember(d => d.Id, op => op.MapFrom(o => o.QualityProperty.Id));
        }
    }
}
