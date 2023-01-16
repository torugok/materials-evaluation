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
            var qualityVisionProperties = new List<Database.QualityVisionProperties>();
            foreach (QualityProperty qualityProperty in qualityVision.QualityProperties)
            {
                qualityVisionProperties.Add(
                    new Database.QualityVisionProperties(
                        Guid.NewGuid(),
                        qualityVision.Id,
                        qualityProperty.Id
                    )
                );
            }

            await _context.AddAsync(
                new Database.QualityVision(
                    qualityVision.Id,
                    qualityVision.Name,
                    qualityVision.AvaliationMethodology.MinQuantity,
                    qualityVision.AvaliationMethodology.Grouping.ToString(),
                    qualityVision.AvaliationMethodology.CalculationType.ToString(),
                    qualityVision.MaterialId,
                    qualityVisionProperties
                )
            );

            Seen.Add(qualityVision);
        }

        public Task<QualityVision> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(QualityVision qualityVision)
        {
            throw new NotImplementedException();

            Seen.Add(qualityVision);
        }

        public async Task Delete(Guid id)
        {
            var qualityVision = await Get(id);
            throw new NotImplementedException();
        }
    }
}
