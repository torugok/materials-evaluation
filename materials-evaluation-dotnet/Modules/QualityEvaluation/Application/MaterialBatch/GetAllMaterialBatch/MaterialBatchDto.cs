using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class MaterialBatchDto
    {
        public Guid Id { get; set; }
        public MaterialDto Material { get; set; }
        public QualityVisionDto QualityVision { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AmountOfTests { get; set; }
        public DateTime? CalculatedAt { get; set; }
        public Status Status { get; set; }
        public List<TestDto> Tests { get; set; }

        public MaterialBatchDto(
            Guid id,
            MaterialDto material,
            QualityVisionDto qualityVision,
            DateTime createdAt,
            int amountOfTests,
            DateTime? calculatedAt,
            Status status,
            List<TestDto> tests
        )
        {
            Id = id;
            Material = material;
            QualityVision = qualityVision;
            CreatedAt = createdAt;
            AmountOfTests = amountOfTests;
            CalculatedAt = calculatedAt;
            Status = status;
            Tests = tests;
        }
    }
}
