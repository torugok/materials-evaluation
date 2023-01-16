using System.Text.Json.Serialization;
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

    public class AvaliationMethodology : ValueObject
    {
        public int MinQuantity { get; set; }

        public Grouping Grouping { get; set; }

        public CalculationType CalculationType { get; set; }

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
