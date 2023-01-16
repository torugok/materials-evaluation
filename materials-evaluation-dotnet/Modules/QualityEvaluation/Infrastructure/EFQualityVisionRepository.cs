using MaterialsEvaluation.Modules.QualityEvaluation.Domain;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFQualityVisionRepository : IQualityVisionRepository
    {
        public List<QualityVision> Seen { get; set; } // FIXME: buscar alternativa para despacho de eventos

        private readonly Database.DatabaseContext _context;

        public EFQualityVisionRepository(Database.DatabaseContext context)
        {
            _context = context;
            Seen = new List<QualityVision>();
        }

        public async Task Insert(QualityVision qualityVision)
        {
            Seen.Add(qualityVision);
            await _context.AddAsync(
                new Database.QualityVision(
                    qualityVision.Id,
                    qualityVision.Name,
                    qualityVision.AvaliationMethodology.MinQuantity,
                    qualityVision.AvaliationMethodology.Grouping.ToString(),
                    qualityVision.AvaliationMethodology.CalculationType.ToString(),
                    qualityVision.MaterialId,
                    new List<Database.QualityVisionProperties>()
                )
            );
        }

        public Task<QualityVision> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(QualityVision qualityVision)
        {
            Seen.Add(qualityVision);
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var qualityVision = await Get(id);
            throw new NotImplementedException();
        }
    }
}
