namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IUnitOfWork
    {
        public IMaterialRepository MaterialRepository { get; }
        public IQualityVisionRepository QualityVisionRepository { get; }
        public IBatchRepository BatchRepository { get; }

        public Task<int> Commit(CancellationToken cancellationToken);
    }
}
