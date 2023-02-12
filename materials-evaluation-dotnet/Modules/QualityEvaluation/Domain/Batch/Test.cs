using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Test : ValueObject // FIXME: o teste se encaixa melhor como entidade!
    {
        public Guid QualityPropertyId { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }
        public bool? Passed { get; set; }

        public Test(Guid qualityPropertyId, bool? resultQualitative, double? resultQuantitative)
        {
            if (resultQualitative == null && resultQuantitative == null)
            {
                throw new BusinessException(
                    "Operação não permitida, necessita um valor pelo menos!"
                );
            }

            QualityPropertyId = qualityPropertyId;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
