using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public enum Grouping
    {
        First,
        Last
    }

    public enum CalculationType
    {
        Median
    }

    public readonly struct AvaliationMethodology
    {
        public int MinQuantity { get; }

        public Grouping Grouping { get; }

        public CalculationType CalculationType { get; }

        public AvaliationMethodology() { }

        public AvaliationMethodology(
            int minQuantity,
            Grouping grouping,
            CalculationType calculatiorType
        )
        {
            MinQuantity = minQuantity;
            Grouping = grouping;
            CalculationType = calculatiorType;
        }
    }
}
