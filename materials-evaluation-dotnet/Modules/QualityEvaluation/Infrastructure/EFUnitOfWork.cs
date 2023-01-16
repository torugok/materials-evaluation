using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Database.DatabaseContext _context;
        public IQualityVisionRepository QualityVisionRepository { get; }

        public EFUnitOfWork(
            Database.DatabaseContext context,
            IQualityVisionRepository qualityVisionRepository
        )
        {
            _context = context;
            QualityVisionRepository = qualityVisionRepository;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            // TODO: add dispatch events from repositories
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
