using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Database.DatabaseContext _context;
        public IQualityVisionRepository QualityVisionRepository { get; }
        public IBatchRepository BatchRepository { get; }
        public IMaterialRepository MaterialRepository { get; }

        public EFUnitOfWork(
            Database.DatabaseContext context,
            IQualityVisionRepository qualityVisionRepository,
            IBatchRepository batchRepository,
            IMaterialRepository materialRepository
        )
        {
            _context = context;
            QualityVisionRepository = qualityVisionRepository;
            BatchRepository = batchRepository;
            MaterialRepository = materialRepository;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            // TODO: add dispatch events from repositories
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
