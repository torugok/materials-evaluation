namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IQualityVisionRepository
    {
        public Task Insert(QualityVision qualityVision);

        public Task<QualityVision?> Get(Guid id);

        public Task Update(QualityVision qualityVision);

        public Task Delete(Guid id);
    }
}
