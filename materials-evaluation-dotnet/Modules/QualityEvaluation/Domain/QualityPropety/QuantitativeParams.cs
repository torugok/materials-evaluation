using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class QuantitativeParams : ValueObject
    {
        public int? Decimals { get; set; }

        public string? Unit { get; set; }

        public double? NominalValue { get; set; }

        public double? InferiorLimit { get; set; }

        public double? SuperiorLimit { get; set; }

        public QuantitativeParams() { }

        public QuantitativeParams(
            int? decimals,
            string? unit,
            double? nominalValue,
            double? inferiorLimit,
            double? superiorLimit
        )
        {
            Decimals = decimals;
            Unit = unit;
            NominalValue = nominalValue;
            InferiorLimit = inferiorLimit;
            SuperiorLimit = superiorLimit;
        }
    }
}
