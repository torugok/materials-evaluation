using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public enum Status
    {
        Pending,
        OutOfRange,
        InRange
    }

    public class MaterialBatch : AggregateRoot
    {
        public Material Material { get; set; }
        public QualityVision QualityVision { get; set; }
        public DateTime CreatedAt { get; }
        public int AmountOfTests { get; set; }
        public DateTime? CalculatedAt { get; set; }
        public List<Test> Tests { get; set; }
        public Status Status { get; set; }

        public MaterialBatch(
            Material material,
            QualityVision qualityVision,
            DateTime createdAt,
            int amountOfTests,
            DateTime? calculatedAt,
            List<Test> tests,
            Status status
        )
        {
            if (qualityVision.MaterialId != material.Id)
            {
                // TODO: criar exceção "business"
                throw new Exception(
                    "Operação não permitida! A visão de qualidade pertencer ao material."
                );
            }
            Material = material;
            QualityVision = qualityVision;
            CreatedAt = createdAt;
            AmountOfTests = amountOfTests;
            CalculatedAt = calculatedAt;
            Tests = tests;
            Status = status;
        }

        public static MaterialBatch Create(Material material, QualityVision qualityVision)
        {
            var materialBatch = new MaterialBatch(
                material,
                qualityVision,
                DateTime.UtcNow,
                0,
                null,
                new List<Test>(),
                Status.Pending
            );
            materialBatch.AddDomainEvent(new MaterialBatchCreated());
            return materialBatch;
        }
    }
}
