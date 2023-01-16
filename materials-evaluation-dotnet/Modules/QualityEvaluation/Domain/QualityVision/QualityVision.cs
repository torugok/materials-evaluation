using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public class QualityVision : AggregateRoot
    {
        public Guid MaterialId { get; set; }

        public string Name { get; set; }

        public AvaliationMethodology AvaliationMethodology { get; set; }

        public List<QualityProperty> QualityProperties { get; set; }

        private QualityVision(
            Guid materialId,
            string name,
            AvaliationMethodology avaliationMethodology,
            List<QualityProperty> qualityProperties
        )
        {
            MaterialId = materialId;
            Name = name;
            AvaliationMethodology = avaliationMethodology;
            QualityProperties = qualityProperties;
        }

        public static QualityVision Create(
            Guid materialId,
            string name,
            AvaliationMethodology avaliationMethodology
        )
        {
            var qualityVision = new QualityVision(
                materialId,
                name,
                avaliationMethodology,
                new List<QualityProperty>()
            );
            qualityVision.AddDomainEvent(new QualityVisionCreated());
            return qualityVision;
        }
    }
}
