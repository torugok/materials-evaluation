using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Test : ValueObject
    {
        public Guid QualityPropertyId { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public Test(Guid qualityPropertyId, bool? resultQualitative, double? resultQuantitative)
        {
            if (resultQualitative == null && resultQuantitative == null)
            {
                // TODO: criar exceções "business"
                throw new Exception("Operação não permitida");
            }

            QualityPropertyId = qualityPropertyId;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
