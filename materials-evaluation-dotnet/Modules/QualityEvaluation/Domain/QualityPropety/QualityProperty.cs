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

        private QualityProperty(
            string acronym,
            string description,
            PropertyTypes type,
            QuantitativeParams? quantitativeParams
        )
        {
            Acronym = acronym;
            Description = description;
            Type = type;
            QuantitativeParams = quantitativeParams;
        }

        public static QualityProperty Create(
            string acronym,
            string description,
            PropertyTypes type,
            QuantitativeParams? quantitativeParams
        )
        {
            return new QualityProperty(acronym, description, type, quantitativeParams);
        }

        public void Edit(
            string acronym,
            string description,
            PropertyTypes type,
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
