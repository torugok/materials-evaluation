using Autofac;
using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;
using MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure;
using AutoMapper.Extensions.EnumMapping;

namespace MaterialsEvaluation.Modules.QualityEvaluation
{
    public class QualityEvaluationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c =>
                {
                    var context = c.Resolve<IComponentContext>();
                    var config = context.Resolve<MapperConfiguration>();

                    return config.CreateMapper(context.Resolve);
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFQualityVisionRepository>()
                .As<Domain.IQualityVisionRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFBatchRepository>()
                .As<Domain.IBatchRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFMaterialRepository>()
                .As<Domain.IMaterialRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFUnitOfWork>()
                .As<Domain.IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder
                .Register(
                    _ =>
                        new MapperConfiguration(cfg =>
                        {
                            cfg.EnableEnumMappingValidation();

                            // Database to DTOs
                            cfg.CreateProjection<Database.Test, TestDto>();
                            cfg.CreateProjection<Database.Material, MaterialDto>();

                            cfg.CreateProjection<
                                Database.QualityVisionProperties,
                                QualityPropertyDto
                            >()
                                .ForMember(
                                    d => d.QuantitativeParams,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                new Domain.QuantitativeParams(
                                                    o.QualityProperty.QuantitativeDecimals.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeUnit
                                                        ?? string.Empty,
                                                    o.QualityProperty.QuantitativeNominalValue.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeInferiorLimit.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeSuperiorLimit.GetValueOrDefault()
                                                )
                                        )
                                )
                                .ForMember(
                                    d => d.Acronym,
                                    op => op.MapFrom(o => o.QualityProperty.Acronym)
                                )
                                .ForMember(
                                    d => d.Description,
                                    op => op.MapFrom(o => o.QualityProperty.Description)
                                )
                                .ForMember(
                                    d => d.Type, // FIXME: usar enum
                                    op => op.MapFrom(o => o.QualityProperty.Type)
                                )
                                .ForMember(d => d.Id, op => op.MapFrom(o => o.QualityProperty.Id));

                            cfg.CreateProjection<Database.QualityProperty, QualityPropertyDto>()
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
                            cfg.CreateProjection<Database.QualityVision, QualityVisionDto>()
                                .ForMember(
                                    d => d.AvaliationMethodology,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                new Domain.AvaliationMethodology(
                                                    o.AvaliationMinQuantity,
                                                    Enum.Parse<Domain.Grouping>(
                                                        o.AvaliationGrouping
                                                    ),
                                                    Enum.Parse<Domain.CalculationType>(
                                                        o.AvaliationCalculationType
                                                    )
                                                )
                                        )
                                );
                            cfg.CreateProjection<Database.Batch, BatchDto>()
                                .ForCtorParam(
                                    nameof(BatchDto.Status),
                                    m => m.MapFrom(x => Enum.Parse<Domain.Status>(x.Status))
                                )
                                .ForMember(
                                    d => d.Status,
                                    op => op.MapFrom(o => Enum.Parse<Domain.Status>(o.Status))
                                );

                            // Database To Entities
                            cfg.CreateProjection<Database.Test, Domain.Test>();
                            cfg.CreateProjection<Database.Material, Domain.Material>();
                            cfg.CreateProjection<Database.QualityVision, Domain.QualityVision>()
                                .ForMember(
                                    d => d.AvaliationMethodology,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                new Domain.AvaliationMethodology(
                                                    o.AvaliationMinQuantity,
                                                    Enum.Parse<Domain.Grouping>(
                                                        o.AvaliationGrouping
                                                    ),
                                                    Enum.Parse<Domain.CalculationType>(
                                                        o.AvaliationCalculationType
                                                    )
                                                )
                                        )
                                );
                            cfg.CreateProjection<Database.QualityProperty, Domain.QualityProperty>()
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
                            cfg.CreateProjection<Database.Batch, Domain.Batch>()
                                .ForCtorParam(
                                    nameof(Domain.Batch.Status),
                                    m => m.MapFrom(x => Enum.Parse<Domain.Status>(x.Status))
                                )
                                .ForMember(
                                    d => d.Status,
                                    op => op.MapFrom(o => Enum.Parse<Domain.Status>(o.Status))
                                );

                            cfg.CreateProjection<
                                Database.QualityVisionProperties,
                                Domain.QualityProperty
                            >()
                                .ForCtorParam(
                                    nameof(Domain.QualityProperty.Type),
                                    m =>
                                        m.MapFrom(
                                            x =>
                                                Enum.Parse<Domain.PropertyTypes>(
                                                    x.QualityProperty.Type
                                                )
                                        )
                                )
                                .ForMember(
                                    d => d.Type,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                Enum.Parse<Domain.PropertyTypes>(
                                                    o.QualityProperty.Type
                                                )
                                        )
                                )
                                .ForMember(
                                    d => d.QuantitativeParams,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                new Domain.QuantitativeParams(
                                                    o.QualityProperty.QuantitativeDecimals.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeUnit
                                                        ?? string.Empty,
                                                    o.QualityProperty.QuantitativeNominalValue.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeInferiorLimit.GetValueOrDefault(),
                                                    o.QualityProperty.QuantitativeSuperiorLimit.GetValueOrDefault()
                                                )
                                        )
                                )
                                .ForMember(
                                    d => d.Acronym,
                                    op => op.MapFrom(o => o.QualityProperty.Acronym)
                                )
                                .ForMember(
                                    d => d.Description,
                                    op => op.MapFrom(o => o.QualityProperty.Description)
                                )
                                .ForMember(d => d.Id, op => op.MapFrom(o => o.QualityProperty.Id));
                        })
                )
                .AsSelf()
                .SingleInstance();
        }
    }
}
