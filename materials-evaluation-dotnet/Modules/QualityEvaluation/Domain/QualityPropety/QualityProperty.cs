using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class QualityProperty : AggregateRoot
    {
        public string Acronym { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        public QualityProperty(
            string acronym,
            string description,
            string type,
            QuantitativeParams? quantitativeParams
        )
        {
            Acronym = acronym;
            Description = description;
            Type = type;
            QuantitativeParams = quantitativeParams;
        }
    }
}
