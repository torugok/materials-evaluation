using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class QualityProperty : AggregateRoot
    {
        public string Acronym { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        public QualityProperty() { }

        public QualityProperty(
            Guid id,
            string acronym,
            string description,
            string type,
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
