using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class Test : ValueObject
    {
        public DateTime CreatedAt { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public Test(DateTime createdAt, bool? resultQualitative, double? resultQuantitative)
        {
            if (resultQualitative == null && resultQuantitative == null)
            {
                // TODO: criar exceções "business"
                throw new Exception("Operação não permitida");
            }

            CreatedAt = createdAt;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
