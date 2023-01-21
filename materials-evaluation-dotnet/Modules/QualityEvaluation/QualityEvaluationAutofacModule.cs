using Autofac;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure;
using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries;

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
                .As<IQualityVisionRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFMaterialBatchRepository>()
                .As<IMaterialBatchRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EFMaterialRepository>()
                .As<IMaterialRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder
                .Register(
                    _ =>
                        new MapperConfiguration(cfg =>
                        {
                            cfg.CreateProjection<Database.Material, MaterialDto>();
                            cfg.CreateProjection<Database.QualityVision, QualityVisionDto>()
                                .ForMember(
                                    d => d.AvaliationMethodology,
                                    op =>
                                        op.MapFrom(
                                            o =>
                                                new AvaliationMethodology(
                                                    o.AvaliationMinQuantity,
                                                    Enum.Parse<Grouping>(o.AvaliationGrouping),
                                                    Enum.Parse<CalculationType>(
                                                        o.AvaliationCalculationType
                                                    )
                                                )
                                        )
                                );
                            cfg.CreateProjection<Database.MaterialBatch, MaterialBatchDto>()
                                .ForMember(
                                    d => d.Status,
                                    op => op.MapFrom(o => Enum.Parse<Status>(o.Status))
                                );
                        })
                )
                .AsSelf()
                .SingleInstance();
        }
    }
}
