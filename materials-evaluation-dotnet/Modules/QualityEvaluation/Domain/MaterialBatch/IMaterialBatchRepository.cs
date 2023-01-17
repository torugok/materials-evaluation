namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IMaterialBatchRepository
    {
        public List<MaterialBatch> Seen { get; set; }

        public Task Insert(MaterialBatch qualityVision);

        public Task<MaterialBatch> Get(Guid id);

        public Task Update(MaterialBatch qualityVision);

        public Task Delete(Guid id);
    }
}
