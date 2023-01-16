namespace MaterialsEvaluation.Database
{
    public class QualityVision
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AvaliationMinQuantity { get; set; }
        public string AvaliationGrouping { get; set; }
        public string AvaliationCalculationType { get; set; }

        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

        public List<QualityVisionProperties>? QualityVisionProperties { get; set; }

        public QualityVision() { }

        public QualityVision(
            Guid id,
            string name,
            int avaliationMinQuantity,
            string avaliationGrouping,
            string avaliationCalculationType,
            Guid materialId,
            List<QualityVisionProperties>? qualityVisionProperties
        )
        {
            Id = id;
            Name = name;
            AvaliationMinQuantity = avaliationMinQuantity;
            AvaliationGrouping = avaliationGrouping;
            AvaliationCalculationType = avaliationCalculationType;
            MaterialId = materialId;
            QualityVisionProperties = qualityVisionProperties;
        }
    }

    public class QualityVisionProperties
    {
        public Guid Id { get; set; } // FIXME: usar long para isso

        public Guid QualityVisionId { get; set; }
        public QualityVision QualityVision { get; set; }

        public Guid QualityPropertyId { get; set; }
        public QualityProperty QualityProperty { get; set; }

        public QualityVisionProperties() { }

        public QualityVisionProperties(Guid id, Guid qualityVisionId, Guid qualityPropertyId)
        {
            Id = id;
            QualityVisionId = qualityVisionId;
            QualityPropertyId = qualityPropertyId;
        }
    }
}
