using Autofac;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure;

namespace MaterialsEvaluation.Modules.QualityEvaluation
{
    public class QualityEvaluationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<EFQualityVisionRepository>()
                .As<IQualityVisionRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
