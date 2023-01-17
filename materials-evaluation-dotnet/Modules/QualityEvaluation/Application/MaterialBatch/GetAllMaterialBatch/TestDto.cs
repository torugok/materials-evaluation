using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class TestDto
    {
        public QualityPropertyDto QualityProperty { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public TestDto() { }

        public TestDto(
            QualityPropertyDto qualityProperty,
            DateTime createdAt,
            bool? resultQualitative,
            double? resultQuantitative
        )
        {
            QualityProperty = qualityProperty;
            CreatedAt = createdAt;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
