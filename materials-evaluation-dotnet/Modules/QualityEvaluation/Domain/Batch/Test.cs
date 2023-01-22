using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Test : Entity
    {
        public QualityProperty QualityProperty { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }
        public bool? Passed { get; set; }

        public Test(
            QualityProperty qualityProperty,
            bool? resultQualitative,
            double? resultQuantitative
        )
        {
            if (resultQualitative == null && resultQuantitative == null)
            {
                throw new BusinessException(
                    "Operação não permitida, necessita um valor pelo menos!"
                );
            }

            QualityProperty = qualityProperty;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
