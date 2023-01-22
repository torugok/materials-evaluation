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
            if (MinQuantity < 1)
            {
                throw new BusinessException("A quantidade mínima de ensaios é 1, verifique!");
            }

            MinQuantity = minQuantity;
            Grouping = grouping;
            CalculationType = calculatiorType;
        }
    }
}
