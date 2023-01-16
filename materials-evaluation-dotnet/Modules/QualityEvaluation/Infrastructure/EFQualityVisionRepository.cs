using MaterialsEvaluation;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFQualityVisionRepository : IQualityVisionRepository
    {
        private readonly Database.DatabaseContext _context;

        public EFQualityVisionRepository(Database.DatabaseContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id)
        {
            long kk = 1;
            var material = await _context.Materials.FindAsync(kk);
        }

        public Task<QualityVision> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(QualityVision qualityVision)
        {
            throw new NotImplementedException();
        }

        public Task Update(QualityVision qualityVision)
        {
            throw new NotImplementedException();
        }
    }
}
