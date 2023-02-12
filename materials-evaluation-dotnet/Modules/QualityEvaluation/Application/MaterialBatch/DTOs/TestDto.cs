namespace MaterialsEvaluation.Modules.QualityEvaluation.Application.Queries
{
    public class TestDto
    {
        public QualityPropertyDto QualityProperty { get; set; }
        public bool? ResultQualitative { get; set; }
        public double? ResultQuantitative { get; set; }

        public TestDto() { }

        public TestDto(
            QualityPropertyDto qualityProperty,
            bool? resultQualitative,
            double? resultQuantitative
        )
        {
            QualityProperty = qualityProperty;
            ResultQualitative = resultQualitative;
            ResultQuantitative = resultQuantitative;
        }
    }
}
