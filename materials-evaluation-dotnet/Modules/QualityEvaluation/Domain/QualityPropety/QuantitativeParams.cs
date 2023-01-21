namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public readonly struct QuantitativeParams
    {
        public int Decimals { get; }

        public string Unit { get; }

        public double NominalValue { get; }

        public double InferiorLimit { get; }

        public double SuperiorLimit { get; }

        public QuantitativeParams() { }

        public QuantitativeParams(
            int decimals,
            string unit,
            double nominalValue,
            double inferiorLimit,
            double superiorLimit
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
