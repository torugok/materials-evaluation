namespace MaterialsEvaluation.Modules.QualityEvaluation.Domain
{
    public interface IUnitOfWork
    {
        public IQualityVisionRepository QualityVisionRepository { get; }

        public Task<int> Commit(CancellationToken cancellationToken);
    }
}
