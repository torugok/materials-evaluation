namespace MaterialsEvaluation.Database
{
    public class MaterialBatch
    {
        public Guid Id { get; set; }

        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public Guid QualityVisionId { get; set; }
        public virtual QualityVision QualityVision { get; set; }

        public DateTime CreatedAt { get; set; }
        public int AmountOfTests { get; set; }
        public DateTime? CalculatedAt { get; set; }
        public string Status { get; set; }

        public List<MaterialBatchTests> MaterialBatchTests { get; set; }

        public MaterialBatch(
            Guid id,
            Guid materialId,
            Guid qualityVisionId,
            DateTime createdAt,
            int amountOfTests,
            DateTime? calculatedAt,
            string status
        )
        {
            Id = id;
            MaterialId = materialId;
            QualityVisionId = qualityVisionId;
            CreatedAt = createdAt;
            AmountOfTests = amountOfTests;
            CalculatedAt = calculatedAt;
            Status = status;
        }
    }
}
