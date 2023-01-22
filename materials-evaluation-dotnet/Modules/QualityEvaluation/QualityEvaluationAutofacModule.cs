using Autofac;
using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure;
using MaterialsEvaluation.Modules.QualityEvaluation.Mappers;

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
                            cfg.AddProfile<MaterialProfile>();
                            cfg.AddProfile<QualityPropertyProfile>();
                            cfg.AddProfile<QualityVisionProfile>();
                            cfg.AddProfile<BatchProfile>();
                            cfg.AddProfile<TestProfile>();
                        })
                )
                .AsSelf()
                .SingleInstance();
        }
    }
}
