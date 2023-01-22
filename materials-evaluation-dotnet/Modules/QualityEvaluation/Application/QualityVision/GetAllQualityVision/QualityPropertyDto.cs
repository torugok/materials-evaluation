using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class QualityPropertyDto
    {
        public Guid Id { get; set; }
        public string Acronym { get; set; }

        public string Description { get; set; }

        public PropertyTypes Type { get; set; }

        public QuantitativeParams? QuantitativeParams { get; set; }

        public QualityPropertyDto() { }

        public QualityPropertyDto(
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
