namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IQualityPropertyRepository
    {
        public Task Insert(QualityProperty qualityProperty);

        public Task<QualityProperty?> Get(Guid id);

        public void Update(QualityProperty qualityProperty);

        public Task Delete(Guid id);
    }
}
