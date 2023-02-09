using AutoMapper;
using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Modules.QualityEvaluation.Infrastructure
{
    public class EFQualityVisionRepository : IQualityVisionRepository
    {
        private readonly Database.DatabaseContext _context;
        private readonly IMapper _mapper;

        public EFQualityVisionRepository(Database.DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Insert(QualityVision qualityVision)
        {
            var qualityVisionProperties = new List<Database.QualityVisionProperties>();

            // TODO: refatorar para usar LINQ
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
        }

        public async Task<QualityVision?> Get(Guid id)
        {
            return await _mapper
                .ProjectTo<QualityVision>(
                    _context.QualityVisions
                        .Include("QualityProperties.QualityProperty")
                        .Where(q => q.Id == id)
                )
                .FirstOrDefaultAsync();
        }

        public Task Update(QualityVision qualityVision)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            var qualityVision = await _context.QualityVisions.FindAsync(id);
            if (qualityVision != null)
            {
                _context.QualityVisions.Remove(qualityVision);
            }
        }
    }
}
