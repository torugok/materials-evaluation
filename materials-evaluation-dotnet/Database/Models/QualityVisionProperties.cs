namespace MaterialsEvaluation.Database
{
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
