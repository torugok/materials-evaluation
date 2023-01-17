namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IUnitOfWork
    {
        public IMaterialRepository MaterialRepository { get; }
        public IQualityVisionRepository QualityVisionRepository { get; }
        public IMaterialBatchRepository MaterialBatchRepository { get; }

        public Task<int> Commit(CancellationToken cancellationToken);
    }
}
