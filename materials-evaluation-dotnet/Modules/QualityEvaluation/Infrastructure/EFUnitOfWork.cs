using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Database.DatabaseContext _context;
        public IQualityVisionRepository QualityVisionRepository { get; }
        public IMaterialBatchRepository MaterialBatchRepository { get; }
        public IMaterialRepository MaterialRepository { get; }

        public EFUnitOfWork(
            Database.DatabaseContext context,
            IQualityVisionRepository qualityVisionRepository,
            IMaterialBatchRepository materialBatchRepository,
            IMaterialRepository materialRepository
        )
        {
            _context = context;
            QualityVisionRepository = qualityVisionRepository;
            MaterialBatchRepository = materialBatchRepository;
            MaterialRepository = materialRepository;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            // TODO: add dispatch events from repositories
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
