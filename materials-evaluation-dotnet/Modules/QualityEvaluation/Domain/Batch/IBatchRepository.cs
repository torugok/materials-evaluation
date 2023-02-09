namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IBatchRepository
    {
        public Task Insert(Batch qualityVision);

        public Task<Batch?> Get(Guid id);

        public Task Update(Batch qualityVision);

        public Task Delete(Guid id);
    }
}
