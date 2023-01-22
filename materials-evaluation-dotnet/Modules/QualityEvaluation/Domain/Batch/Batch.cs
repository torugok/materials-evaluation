using MaterialsEvaluation.Shared.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public enum Status
    {
        Pending,
        OutOfRange,
        InRange
    }

    public class Batch : AggregateRoot
    {
        public Material Material { get; set; }
        public QualityVision QualityVision { get; set; }
        public DateTime CreatedAt { get; }
        public int AmountOfTests { get; set; }
        public DateTime? CalculatedAt { get; set; }
        public List<Test> Tests { get; set; }
        public Status Status { get; set; }

        public Batch(
            Guid id,
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
                throw new BusinessException(
                    "Operação não permitida! A visão de qualidade deve pertencer ao material."
                );
            }

            Id = id;
            Material = material;
            QualityVision = qualityVision;
            CreatedAt = createdAt;
            AmountOfTests = amountOfTests;
            CalculatedAt = calculatedAt;
            Tests = tests;
            Status = status;
        }

        public Batch(
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
                throw new BusinessException(
                    "Operação não permitida! A visão de qualidade deve pertencer ao material."
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

        public static Batch Create(Material material, QualityVision qualityVision)
        {
            var batch = new Batch(
                material,
                qualityVision,
                DateTime.UtcNow,
                0,
                null,
                new List<Test>(),
                Status.Pending
            );
            batch.AddDomainEvent(new BatchCreated());
            return batch;
        }

        public void AddTest(List<Test> tests)
        {
            Tests.AddRange(tests);
            AmountOfTests++;
        }

        public void CheckTests()
        {
            Status = Status.InRange;

            // TODO: refatorar para usar business Rules
            if (AmountOfTests >= QualityVision.AvaliationMethodology.MinQuantity)
            {
                foreach (Test test in Tests)
                {
                    foreach (QualityProperty qualityProperty in QualityVision.QualityProperties)
                    {
                        if (qualityProperty.Id == test.QualityPropertyId)
                        {
                            if (qualityProperty.Type == PropertyTypes.Quantitative)
                            {
                                if (
                                    qualityProperty.QuantitativeParams == null
                                    || (
                                        test.ResultQuantitative
                                            < qualityProperty.QuantitativeParams?.InferiorLimit
                                        || test.ResultQuantitative
                                            > qualityProperty.QuantitativeParams?.SuperiorLimit
                                    )
                                )
                                {
                                    test.Passed = false;
                                    Status = Status.OutOfRange;
                                    return;
                                }
                            }
                            else if (qualityProperty.Type == PropertyTypes.Qualitative)
                            {
                                if (test.ResultQualitative == false)
                                {
                                    test.Passed = false;
                                    Status = Status.OutOfRange;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
