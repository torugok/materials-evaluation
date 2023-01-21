using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public enum PropertyTypes
    {
        Quantitative,
        Qualitative
    }

    public class QualityProperty : AggregateRoot
    {
        public string Acronym { get; set; }

        public string Description { get; set; }

        public PropertyTypes Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        public QualityProperty() { }

        public QualityProperty(
            Guid id,
            string acronym,
            string description,
            PropertyTypes type,
            QuantitativeParams? quantitativeParams
        )
        {
            Id = id;
            Acronym = acronym;
            Description = description;
            Type = type;
            QuantitativeParams = quantitativeParams;
        }
    }
}
