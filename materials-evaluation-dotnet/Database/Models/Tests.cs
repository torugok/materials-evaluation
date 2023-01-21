namespace MaterialsEvaluation.Database
{
    public class Tests
    {
        public Guid Id { get; set; }

        public Guid BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        public Guid QualityPropertyId { get; set; }
        public virtual QualityProperty QualityProperty { get; set; }

        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public bool? Passed { get; set; }

        public Tests(
            Guid id,
            Guid batchId,
            Guid qualityPropertyId,
            bool? resultQualitative,
            double? resultQuantitative,
            bool? passed
        )
        {
            Id = id;
            BatchId = batchId;
            QualityPropertyId = qualityPropertyId;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
            Passed = passed;
        }
    }
}
