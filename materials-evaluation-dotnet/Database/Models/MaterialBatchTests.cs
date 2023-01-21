namespace MaterialsEvaluation.Database
{
    public class MaterialBatchTests
    {
        public Guid Id { get; set; }

        public Guid MaterialBatchId { get; set; }
        public virtual MaterialBatch MaterialBatch { get; set; }

        public Guid QualityPropertyId { get; set; }
        public virtual QualityProperty QualityProperty { get; set; }

        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public bool? Result { get; set; }

        public MaterialBatchTests(
            Guid id,
            Guid materialBatchId,
            Guid qualityPropertyId,
            bool? resultQualitative,
            double? resultQuantitative,
            bool? result
        )
        {
            Id = id;
            MaterialBatchId = materialBatchId;
            QualityPropertyId = qualityPropertyId;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
            Result = result;
        }
    }
}
